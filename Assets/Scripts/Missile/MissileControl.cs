using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour {

    private Transform myMissile;//导弹位置
    private Transform myShip;//我的船的位置

    private Ships ship;

    public bool isLife = true;//导弹生命

    private Vector3 normalForward = Vector3.forward;

	// Use this for initialization
	void Start () {
        myMissile = gameObject.GetComponent<Transform>();

        myShip = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ships>();
	}
	
	// Update is called once per frame
	void Update () {

        if(isLife)
        {
            myMissile.Translate(Vector3.forward);

            //导弹追踪
            Vector3 dir = myShip.position - myMissile.position;
            normalForward = Vector3.Lerp(normalForward, dir, Time.deltaTime);
            myMissile.rotation = Quaternion.LookRotation(normalForward);
        }
        
	}

    //导弹碰撞自毁
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Missile" || coll.tag == "ShipMissile")
        {
            GameObject.Destroy(gameObject);
            ship.Explore(myMissile.position);
        }
    }
}
