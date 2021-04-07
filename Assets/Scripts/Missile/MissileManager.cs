using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    private  List<GameObject> myMissile = new List<GameObject>();//在籍导弹

    private Transform myTransform;//当前位置
    private Transform[] creatPoint;//四个导弹发射井

    private GameObject missile;//导弹本体

	// Use this for initialization
	void Start () {
        missile = Resources.Load<GameObject>("Missile_3");

        myTransform = gameObject.GetComponent<Transform>();

        creatPoint = GameObject.Find("CreatPoints").GetComponent<Transform>().GetComponentsInChildren<Transform>();

        InvokeRepeating("CreatMissile", 0, 3);
	}

    /// <summary>
    /// 生成导弹
    /// </summary>
    private void CreatMissile()
    {
        int index = Random.Range(1, creatPoint.Length);
        GameObject temp = GameObject.Instantiate<GameObject>(missile, creatPoint[index].position, Quaternion.identity, myTransform);
        myMissile.Add(temp);
    }

    /// <summary>
    /// 停止生成导弹
    /// </summary>
    public void StopCreatMissile()
    {
        CancelInvoke("CreatMissile");
        //foreach (GameObject go in myMissile)
        //    go.GetComponent<MissileControl>().isLife = false;
    }

    /// <summary>
    /// 销毁在籍导弹
    /// </summary>
    /// <param name="temp"></param>
    public void DeleteMissile(GameObject temp)
    {
        GameObject.Destroy(temp);
        myMissile.Remove(temp);   
    }
}
