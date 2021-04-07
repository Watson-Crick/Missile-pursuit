using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private Transform myShip;
    private Transform myCamera;

    // Use this for initialization
    void Start()
    {
        myCamera = gameObject.GetComponent<Transform>();

        myShip = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        myCamera.position = myShip.position + new Vector3(0, 100, 0);
    }
}
