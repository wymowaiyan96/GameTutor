using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.name == "cointxt")
        {
            GetComponent<TextMesh>().text = "Coins : " + GM.coinTotal;
        }


        if (gameObject.name == "timetxt")
        {
            GetComponent<TextMesh>().text = "Time : " + ((int)GM.timeTotal);
        }

        if (gameObject.name == "runstat")
        {
            GetComponent<TextMesh>().text = GM.levelCompStatus;
        }

    }
}
