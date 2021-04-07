using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    private Rigidbody r;

	// Use this for initialization
	void Start () {
        r = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        r.MovePosition(gameObject.GetComponent<Transform>().position + Vector3.forward);
	}
}
