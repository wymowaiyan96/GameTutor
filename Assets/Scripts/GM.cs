using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float weightToLoad = 0;
    public static float zVelAdj = 1; //zAxis velocity Adjustment
    public static string levelCompStatus ="";
    public float zScenePos = 58; //z Scene Position
    public int randNum;

    public Transform boomObj;
	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        
     
        timeTotal += Time.deltaTime;


        //if (levelCompStatus == "Fail")
        //{
        //   // greater than 2 seconds
        //    weightToLoad += Time.deltaTime;
        //}

        ////checking game is over
        //if (weightToLoad>2)
        //{
        //    SceneManager.LoadScene("LevelComp");
        //}
	}
}
