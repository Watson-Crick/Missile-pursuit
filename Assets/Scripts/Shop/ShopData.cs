using System.Collections;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// 商城功能模块数据处理
/// </summary>
public class ShopData {

    //金币数与最高分数
    public int goldCount = 0;
    public int heightScore = 0;

    public List<ShopItem> shopList = new List<ShopItem>();

    public List<int> shopState = new List<int>();

    //读取飞船用函数
	public void ReadXMLPath(string path)
    {       
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("Shop");
        XmlNodeList nodeList = root.ChildNodes;
        foreach(XmlNode node in nodeList)
        {
            string speed = node.ChildNodes[0].InnerText;
            string rotate = node.ChildNodes[1].InnerText;
            string model = node.ChildNodes[2].InnerText;
            string value = node.ChildNodes[3].InnerText;
            string id = node.ChildNodes[4].InnerText;
            string ship = node.ChildNodes[5].InnerText;

            ShopItem item = new ShopItem(speed, rotate, model, value, id, ship);
            shopList.Add(item);
        }
    }

    //读取玩家信息函数
    public void ReadScoreAndGold(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("SaveData");
        XmlNodeList nodeList = root.ChildNodes;

        goldCount = int.Parse(nodeList[0].InnerText);
        heightScore = int.Parse(nodeList[1].InnerText);

        for (int i = 2; i < nodeList.Count; i++)
        {
            shopState.Add(int.Parse(nodeList[i].InnerText));
        }
    }

    public void UpdateXmlData(string path, string key, string value)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("SaveData");
        XmlNodeList nodeList = root.ChildNodes;

        foreach (XmlNode node in nodeList)
        {
            if (node.Name == key)
            {
                node.InnerText = value;
                doc.Save(path);
            }
        }
    }

    public void UpdateShopState(int index)
    {
        shopState[index] = 1;
    }
}
