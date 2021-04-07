public class ShopItem {

    private string speed;
    private string rotate;
    private string model;
    private string value;
    private string id;
    private string ship;
    
    public ShopItem(string s, string r, string m, string v, string i, string ss)
    {
        speed = s;
        rotate = r;
        model = m;
        value = v;
        id = i;
        ship = ss;
    }
	
	public string Speed
    {
        set { speed = value; }
        get { return speed; }
    }

    public string Rotate
    {
        set { rotate = value; }
        get { return rotate; }
    }

    public string Model
    {
        set { model = value; }
        get { return model; }
    }

    public string Value
    {
        set { this.value = value; }
        get { return value; }
    }

    public string Id
    {
        set { id = value; }
        get { return id; }
    }

    public string Ship
    {
        set { ship = value; }
        get { return ship; }
    }

}
