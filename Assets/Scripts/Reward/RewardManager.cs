using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour {

    private List<GameObject> myReward = new List<GameObject>();

    private GameObject rewards;

    private Transform myself;

    private int rewardCount = 0;
    private int rewardMax = 6;

	// Use this for initialization
	void Start () {
        rewards = Resources.Load<GameObject>("reward");

        myself = gameObject.GetComponent<Transform>();

        InvokeRepeating("CreatReward", 5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 生成奖励
    /// </summary>
    private void CreatReward()
    {
        if (rewardCount < rewardMax)
        {
            Vector3 dir = new Vector3(Random.Range(570, -400), 0, Random.Range(580, -420));
            GameObject temp = GameObject.Instantiate<GameObject>(rewards, dir, Quaternion.identity);
            temp.GetComponent<Transform>().SetParent(myself);
            myReward.Add(temp);

            rewardCount++;
        }
        
    }

    /// <summary>
    /// 停止生成奖励
    /// </summary>
    public void StopCreatReward()
    {
        CancelInvoke();
    }

    public void RewardCountDown()
    {
        rewardCount--;
    }

}
