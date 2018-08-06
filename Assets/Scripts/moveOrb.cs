using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class moveOrb : MonoBehaviour {

    public KeyCode MoveL;
    public KeyCode MoveR;

    public int laneNum =2;
    //lock playing from movement while switching
    public string controlLock = "N";
    public float horiVel = 0;

    //public Transform boomObj;   

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //camera follow user
        GetComponent<Rigidbody>().velocity = new Vector3(horiVel, GM.vertVel, 4);

        //keep track of which lane, otherwise (keep moving left)
        if ((Input.GetKeyDown(MoveL) && (laneNum > 1) && controlLock == "N"))
        {
            horiVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLock = "Y";
        }

        if ((Input.GetKeyDown(MoveR) && (laneNum <3) && controlLock == "N"))
        {
            horiVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLock = "Y";
        }
    }

    //wait half a second and then set it back to 0
    IEnumerator stopSlide ()
    {
        yield return new WaitForSeconds(.5f);
        horiVel = 0;
        controlLock = "N";
    }

    //check collide with which object
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
            
            GM.zVelAdj = 0;
            //transform.position will grab the position, boomObj will follow whereever player go
           // Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.levelCompStatus = "Fail";
            
            
                
        }

        //power up Dissapear
        //clone if object get instentiated
        if (other.gameObject.name == "Capsule(Clone)")
        {
            Destroy(other.gameObject);
        }

    }

    //trigger by a collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "exit")
        {
            GM.levelCompStatus = "Success";
            SceneManager.LoadScene("LevelComp");
        }

        if (other.gameObject.name == "Coin(Clone)")
        {
            Destroy(other.gameObject);
            GM.coinTotal += 1; //coin score count incremented here

        }

       
    }

    public void SetSpeed(float modifyer)
    {
       GM.zVelAdj = 5.0f + modifyer;
    }
}
