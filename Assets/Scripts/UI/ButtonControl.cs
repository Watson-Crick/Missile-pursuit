using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {
    private GameObject Right;
    private GameObject Left;

    private Ships myShip;

	// Use this for initialization
	void Start () {
        Right = GameObject.Find("Right");
        Left = GameObject.Find("Left");

        UIEventListener.Get(Right).onPress = RightPress;
        UIEventListener.Get(Left).onPress = LeftPress;

        myShip = GameObject.FindGameObjectWithTag("Player").GetComponent<Ships>();

    }




    private void LeftPress(GameObject go, bool isPress)
    {
        if (isPress)
        {
            myShip.IsLeft = true;
            
        }
        else
        {
            myShip.IsLeft = false;
            
        }
    }
    private void RightPress(GameObject go, bool isPress)
    {
        if (isPress)
        {
            myShip.IsRight = true;
            
        }
        else
        {
            myShip.IsRight = false;
           
        }
    }

}
