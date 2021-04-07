using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    private ShopData shopData;
    private StartUIManager startUIManager;

    private GameObject shopItem;
    private GameObject leftButton;
    private GameObject rightButton;

    //最高分数与金币的UILable
    private UILabel goldNum;
    private UILabel maxScore;

    //飞船数据存储路径
    private string xmlPath = "Assets/Datas/ShopData.xml";

    //玩家存档路径
    private string savePath = "Assets/Datas/SaveData.xml";

    private List<GameObject> ShopUI = new List<GameObject>();

    //要展示的UI的索引
    private int index = 0;

	void Start () {

        shopItem = Resources.Load<GameObject>("ShopItem");

        startUIManager = GameObject.Find("UI Root").GetComponent<StartUIManager>();

        //实例化ShopData
        shopData = new ShopData();

        //加载飞船相关xml
        shopData.ReadXMLPath(xmlPath);

        //加载存档相关xml
        shopData.ReadScoreAndGold(savePath);

        //生成相对应的UI
        CreatShopUI();

        //查找金币与最高分数的UILable
        goldNum = GameObject.Find("UI Root/StartPanel/Score/StarNum").GetComponent<UILabel>();
        maxScore = GameObject.Find("UI Root/StartPanel/Score/BestScore").GetComponent<UILabel>();
        int nowScore = PlayerPrefs.GetInt("MaxScore", 0);
        if (nowScore > shopData.heightScore)
        {
            //更新UI
            UpdateScoreUI(nowScore);
            //更新XML
            shopData.UpdateXmlData(savePath, "HeightScore", nowScore.ToString());
        }
        else
        {
            UpdateScoreUI(shopData.heightScore);
        }
        int gold = PlayerPrefs.GetInt("Gold", 0);
        if (gold > 0)
        {
            //更新UI
            UpdateGoldUI(gold + shopData.goldCount);
            //更新XML
            shopData.UpdateXmlData(savePath, "GoldCount", gold.ToString());
        }
        else
        {
            UpdateGoldUI(shopData.goldCount);
        }

        //查找左右按钮
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");

        //左右按钮监听
        UIEventListener.Get(leftButton).onClick = LeftButtonClick;
        UIEventListener.Get(rightButton).onClick = RightButtonClick;

        SetPlayerInfo(shopData.shopList[0].Ship);
    }

    //更新金币UI
    private void UpdateGoldUI(int gold)
    {
        goldNum.text = gold.ToString();
    }

    //更新分数UI
    private void UpdateScoreUI(int score)
    {
        maxScore.text = score.ToString();
    }
	
    //创建shopUI
	private void CreatShopUI()
    {

        for (int i = 0;i < shopData.shopList.Count; i++)
        {
            GameObject item = NGUITools.AddChild(gameObject, shopItem);
            GameObject ship = Resources.Load<GameObject>(shopData.shopList[i].Model);

            item.GetComponent<ShopItemUI>().SetUI(shopData.shopList[i].Speed, shopData.shopList[i].Rotate, shopData.shopList[i].Value, ship, shopData.shopState[i], shopData.shopList[i].Id);

            //加入ShopUI中
            ShopUI.Add(item);
        }

        ShopUIControl();
    }

    //左键绑定函数
    private void LeftButtonClick(GameObject go)
    {
        if (index > 0)
            index--;
        ShopUIControl();
        startUIManager.SetStarGameButtonState(shopData.shopState[index]);
        SetPlayerInfo(shopData.shopList[index].Ship);
    }

    //右键绑定函数
    private void RightButtonClick(GameObject go)
    {
        if (index < ShopUI.Count - 1)
            index++;
        ShopUIControl();
        startUIManager.SetStarGameButtonState(shopData.shopState[index]);
        SetPlayerInfo(shopData.shopList[index].Ship);
    }

    //ShopUI的展示与隐藏
    private void ShopUIControl()
    {
        for (int i = 0; i < ShopUI.Count; i++)
        {
            ShopUI[i].SetActive(false);
        }
        //展示对应商品
        ShopUI[index].SetActive(true);
    }

    //计算金币是否足够
    private void CalcItemPrice(ShopItemUI item)
    {
        if (shopData.goldCount >= item.price)
        {
            Debug.Log("购买成功");
            item.BuyEnd();
            shopData.goldCount -= item.price;
            UpdateGoldUI(shopData.goldCount);
            UpdateScoreUI(shopData.heightScore);

            //更新xml中商品状态
            shopData.UpdateXmlData(savePath, "GoldCount", shopData.goldCount.ToString());
            shopData.UpdateXmlData(savePath, "ID" + item.id, "1");
            shopData.UpdateShopState(item.id);
            startUIManager.SetStarGameButtonState(shopData.shopState[index]);
        }
        else
        {
            Debug.Log("购买失败");
        }
    }

    //存储当前角色信息
    private void SetPlayerInfo(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
    }

    
}
