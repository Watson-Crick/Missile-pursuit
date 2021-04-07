using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour {

    private GameObject StartPanel;
    private GameObject SetPanel;

    private GameObject ButtonSet;
    private GameObject ButtonSetClose;
    private GameObject ButtonStartGame;

	// Use this for initialization
	void Start () {
        StartPanel = GameObject.Find("StartPanel");
        SetPanel = GameObject.Find("SetPanel");

        ButtonSet = GameObject.Find("Set");
        ButtonSetClose = GameObject.Find("Close");
        ButtonStartGame = GameObject.Find("StartGame");

        UIEventListener.Get(ButtonSet).onClick = SettingButtonClick;
        UIEventListener.Get(ButtonSetClose).onClick = SetCloseButtonClick;
        UIEventListener.Get(ButtonStartGame).onClick = StartGameButtonClick;

        //设置默认关闭
        SetPanel.SetActive(false);       
	}

    //绑定关闭按钮单击事件
    private void SetCloseButtonClick(GameObject go)
    {
        SetPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    //绑定设置按钮单击事件
    private void SettingButtonClick(GameObject go)
    {
        if (!SetPanel.activeSelf)
        {
            SetPanel.SetActive(true);
        }
    }

    //绑定开始按钮单机事件
    private void StartGameButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Game");
    }

    //开始按钮的隐藏与显示
    public void SetStarGameButtonState(int state)
    {
        if (state == 1)
        {
            ButtonStartGame.SetActive(true);
        }
        else if (state == 0)
        {
            ButtonStartGame.SetActive(false);
        }
    }
}
