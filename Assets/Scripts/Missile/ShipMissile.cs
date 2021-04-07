using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMissile : MonoBehaviour {

    private Ships ship;

    private Transform myMissile;//导弹位置

    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ships>();

        myMissile = gameObject.GetComponent<Transform>();

        Invoke("Boom", 5.0f);
    }

    void Update () {
        gameObject.GetComponent<Transform>().Translate(Vector3.forward * 3);
	}

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Border" || coll.tag == "Missile")
        {
            Boom();
        }
    }

    private void Boom()
    {
        GameObject.Destroy(gameObject);
        ship.Explore(myMissile.position);
    }
}
