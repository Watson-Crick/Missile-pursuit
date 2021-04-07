using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {

    private GameObject nowShip;

	// Use this for initialization
	void Awake () {
        nowShip = Resources.Load<GameObject>(PlayerPrefs.GetString("PlayerName"));
        GameObject temp = GameObject.Instantiate<GameObject>(nowShip, Vector3.zero, Quaternion.identity);
        temp.AddComponent<Ships>();
    }
	
}
