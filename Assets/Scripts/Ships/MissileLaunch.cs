using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLaunch : MonoBehaviour {

    private GameObject missile;

    private Transform ship;
    private Transform missileSilo;

    private int missileCount = 5;

	// Use this for initialization
	void Start () {
        missile = Resources.Load<GameObject>("Missile_1");
        ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        missileSilo = gameObject.GetComponent<Transform>();

        InvokeRepeating("MissileCountAdd", 0, 5);
	}
	
	//// Update is called once per frame
	//void Update () {
         //MissileMove();
	//}

    //导弹产生以及移动过程
    private void MissileMove()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (missileCount > 0)
            {
                missileCount--;

                GameObject temp = GameObject.Instantiate<GameObject>(missile, missileSilo.position, Quaternion.identity);
                temp.GetComponent<Transform>().localRotation = ship.GetComponent<Transform>().localRotation;
            }
        }
    }

    //导弹数量增加
    public void MissileCountAdd()
    {
        if (missileCount < 5)
        {
            missileCount++;
        }
    }
}
