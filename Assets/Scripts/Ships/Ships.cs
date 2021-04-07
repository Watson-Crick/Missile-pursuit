using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour {

    private GameObject Boom;//特效

    private Transform myself;//自身位置

    private bool isLeft = false;//左转
    private bool isRight = false;//右转

    private bool isLive = false;//飞船生命

    public bool IsRight
    {
        get { return isRight; }
        set { isRight = value; }
    }

    public bool IsLeft
    {
        get { return isLeft; }
        set { isLeft = value; }
    }

    private MissileManager myMissile;//获取导弹管理组件
    private RewardManager myReward;//获取奖励管理组件
    private GameUIManager myGameUI;

    private int score = 0;

    void Start () {
        Boom = Resources.Load<GameObject>("Smoke03");

        myself = gameObject.GetComponent<Transform>();

        myMissile = GameObject.Find("MissileManager").GetComponent<MissileManager>();
        myReward = GameObject.Find("RewardManager").GetComponent<RewardManager>();
        myGameUI = GameObject.Find("UI Root").GetComponent<GameUIManager>();

        isLive = true;
	}
	
    void Update () {

        MoveControl();
        
    }

    /// <summary>
    /// 移动控制
    /// </summary>
    /// <param name="dir"></param>
    private void MoveControl()
    {
        myself.Translate(Vector3.forward * 1.5f);
        if (isLeft)
        {
            myself.Rotate(Vector3.up * 1);
        }
        else if (isRight)
        {
            myself.Rotate(Vector3.up * -1);
        }
    }

    /// <summary>
    /// 播放爆炸特效
    /// </summary>
    /// <param name="dir"></param>
    public void Explore(Vector3 dir)
    {
        GameObject.Instantiate(Boom, dir, Quaternion.identity);
    }

    /// <summary>
    /// 飞机坠毁条件
    /// </summary>
    /// <param name="coll"></param>
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Border")
        {
            MyShipCrash();
        }
        else if(coll.tag == "Missile")
        {
            MyShipCrash();
            myMissile.DeleteMissile(coll.gameObject);
        }
        else if (coll.tag == "Reward")
        {
            GameObject.Destroy(coll.gameObject);
            myReward.RewardCountDown();
            score++;
            myGameUI.UpdateScore(score);
        }
    }

    /// <summary>
    /// 飞机坠毁
    /// </summary>
    private void MyShipCrash()
    {
        Explore(myself.position);
        gameObject.SetActive(false);

        myMissile.StopCreatMissile();

        myReward.StopCreatReward();

        myGameUI.ShowOverPanel();
    }
}
