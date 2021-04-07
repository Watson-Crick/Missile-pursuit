using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardControl : MonoBehaviour {

    private Transform myself;

	void Start () {
        myself = gameObject.GetComponent<Transform>();
	}
	
	void Update () {
        myself.Rotate(Vector3.left);
	}
}
