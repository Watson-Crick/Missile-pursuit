using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemUI : MonoBehaviour {

    private Transform myself;

    private UILabel speed;  //飞船速度
    private UILabel rotate;  //飞船转弯灵活度
    private UILabel value;  //飞船价值

    private GameObject myModel;  //飞船模型的上级
    private GameObject buyButton;  //绑定购买按钮
    private GameObject itemState;  //物品状态

    public int price;
    public int id;

    void Awake () {
        myself = gameObject.GetComponent<Transform>();

        speed = myself.FindChild("Speed/SpeedNum").GetComponent<UILabel>();
        rotate = myself.FindChild("Rotate/RotateNum").GetComponent<UILabel>();
        value = myself.FindChild("BuyButton/Value").GetComponent<UILabel>();
        myModel = myself.FindChild("Model").gameObject;
        buyButton = myself.FindChild("BuyButton/BG").gameObject;
        itemState = myself.FindChild("BuyButton").gameObject;

        UIEventListener.Get(buyButton).onClick = BuyButtonClick;
	}

    public void SetUI(string speed, string rotate, string value, GameObject model, int state, string id)
    {
        this.speed.text = speed;
        this.rotate.text = rotate;
        this.value.text = value;
        this.id = int.Parse(id);

        price = int.Parse(value);

        //判断是否购买飞船
        if (state == 1)
            itemState.SetActive(false);

        GameObject myShip = NGUITools.AddChild(myModel, model); //这个返回的是Model下的物体并非Model
        myShip.layer = 8; //设置模型层级为NUGI层
        Transform shipTransform = myShip.GetComponent<Transform>(); //用于中转（原因未知）
        shipTransform.GetComponent<Transform>().FindChild("Mesh").gameObject.layer = 8; //设置子物体的层级为8

        if (id == "3")
        {
            shipTransform.localPosition = new Vector3(0, 140, 0);
            shipTransform.localScale = new Vector3(5, 5, 5);
        }
        else
        {
            shipTransform.localPosition = new Vector3(0, 200, 0);
            shipTransform.localScale = new Vector3(15, 15, 15);
        }
        shipTransform.localRotation = Quaternion.Euler(-90, 0, 0);
    }
	
    //购买按钮事件
    private void BuyButtonClick(GameObject go)
    {
        SendMessageUpwards("CalcItemPrice", this);
    }

    //购买成功后事件
    public void BuyEnd()
    {
        itemState.SetActive(false);
    }
}
