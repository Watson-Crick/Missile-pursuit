using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

    private GameObject ButtonReset;
    private GameObject OverPanel;

    private UILabel StartNum;  //游戏过程中星星的值
    private UILabel GameTime;  //游戏过程中展示的时间
    private UILabel EndStar;  //游戏结束时星星的值
    private UILabel EndTime;  //游戏结束时时间的值
    private UILabel EndScore;

    private GameObject ButtonControl;

    private int time = 0;

    public int Time
    {
        set{ time = value; }
        get { return time; }
    }

    // Use this for initialization
    void Start () {
        OverPanel = GameObject.Find("OverPanel");
        StartNum = GameObject.Find("StartNum1").GetComponent<UILabel>();
        GameTime = GameObject.Find("GameTime").GetComponent<UILabel>();
        EndStar = GameObject.Find("StartNum").GetComponent<UILabel>();
        EndTime = GameObject.Find("TimeNum").GetComponent<UILabel>();
        EndScore = GameObject.Find("FinalScore").GetComponent<UILabel>();

        GameTime.text = "0:0";
        StartCoroutine("AddTime");
        ButtonControl = GameObject.Find("ButtonControl");

        ButtonReset = GameObject.Find("Reset");

        UIEventListener.Get(ButtonReset).onClick = ResetButtonOnClick;

        OverPanel.SetActive(false);
	}
	
    /// <summary>
    /// 重新开始按钮绑定单击事件
    /// </summary>
    /// <param name="go"></param>
    private void ResetButtonOnClick(GameObject go)
    {
        SceneManager.LoadScene("Start");
    }

    /// <summary>
    /// 展示结束Ui
    /// </summary>
    public void ShowOverPanel()
    {
        OverPanel.SetActive(true);
        ButtonControl.SetActive(false);
        ChangeLastEvaluate();
        StopAddTime();
    }

    /// <summary>
    /// 更新分数
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        StartNum.text = score.ToString();
    }

    /// <summary>
    /// 协程解决时间累加
    /// </summary>
    /// <returns></returns>
    IEnumerator AddTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Time++;
            
            UpdateTimeLable();
        }
    }

    /// <summary>
    /// 停止时间累加
    /// </summary>
    private void StopAddTime()
    {
        StopCoroutine("AddTime");
        Time = 0;
    }

    /// <summary>
    /// 更新时间UI
    /// </summary>
    private void UpdateTimeLable()
    {
        if (Time > 60)
        {
            GameTime.text = (Time / 60).ToString() + ":" + (Time % 60).ToString();
        }
        else
        {
            GameTime.text = "0:" + Time.ToString();
        }
    }

    /// <summary>
    /// 修改最终评价UI
    /// </summary>
    private void ChangeLastEvaluate()
    {
        EndStar.text = "+" + (int.Parse(StartNum.text) * 10).ToString();
        EndTime.text = "+" + Time.ToString();
        EndScore.text = (Time + int.Parse(EndStar.text)).ToString();
        //存储金币与最高分数
        PlayerPrefs.SetInt("MaxScore", int.Parse(EndScore.text));
        PlayerPrefs.SetInt("Gold", int.Parse(EndStar.text));
    }
}
