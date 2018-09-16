using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector; //to move diff direction;
    private float vertVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 2.0f;
    private bool isDead = false; //not dead when start
    private float startTime;
    private float jumpSpeed = 0.0f; //jump speed

    bool speedFlag = true; //flag for speed candy

    private float waitTime = 0.0f;

    public Transform boomObj;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        //restricting control. only after camera animation, player can move
        if (Time.time - startTime < animationDuration)
        //{
        //    controller.Move(Vector3.forward * speed * Time.deltaTime);
        //    return;
        //}

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            vertVelocity = -0.5f;
        }
        else
        {
            vertVelocity -= gravity * Time.deltaTime;
        }

        controller.Move(Vector3.forward * speed * Time.deltaTime);

        //X left and right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y UP and Down
        moveVector.y = vertVelocity;
        //if (moveVector.y < 2.0f)
        //{
            if (Input.GetButton("Jump"))
                moveVector.y = jumpSpeed;
        //}


        // Z forward and background
        controller.Move(moveVector * Time.deltaTime);


    }


    public void SetSpeed(float modifyer)
    {
        speed = 5.0f + modifyer;
    }

    //called when the player hit something
    private IEnumerator OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if collide with an obstacles
        if (hit.gameObject.tag == "lethal")
        {          
            Instantiate(boomObj, transform.position, boomObj.rotation);           
                Death();           
         }       

        if (hit.gameObject.tag == "pit")
        {
            Death();
        }
        if (hit.gameObject.CompareTag("speed")) //power-up speed
        {
            FindObjectOfType<AudioManager>().Play("PowerUpSpeed"); //power-up speed sound effect
            speedFlag = true;
            //Destroy(hit.gameObject);
            //hit.gameObject.GetComponent<Renderer>().enabled = false;
            hit.gameObject.SetActive(false);
            float orgSpeed = speed; //save origianl speed for restoration
            speed += 15.0f;
            StartCoroutine(ObstaclesDisappear(true));
            yield return new WaitForSeconds(3);
            speedFlag = false;
            speed = orgSpeed;

        }

        if (hit.gameObject.CompareTag("jump")) //power-up jump
        {
            FindObjectOfType<AudioManager>().Play("PowerUpJump"); //power-up jump sound effect
            //hit.gameObject.GetComponent<Renderer>().enabled = false;
            //Destroy(hit.gameObject); // attempt to fix run backward (MissingReferenceException)
            hit.gameObject.SetActive(false);

            jumpSpeed = 30.0f;
            yield return new WaitForSeconds(2);
            jumpSpeed = 0.0f;
        }

        if (hit.gameObject.CompareTag("coin"))
        {
            FindObjectOfType<AudioManager>().Play("Coin"); //coin sound effect
            hit.gameObject.SetActive(false);
            //hit.gameObject.GetComponent<Renderer>().enabled = false;
            //Destroy(hit.gameObject); // attempt to fix run backward (MissingReferenceException)
        }

    }

    private void Death()
    {
        isDead = true;
        //stop music and sounds
        FindObjectOfType<AudioManager>().Stop("Coin");
        FindObjectOfType<AudioManager>().Stop("PowerUpJump");
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("PlayerDeath"); //play death music
        GetComponent<Score>().OnDeath();
    }

    private IEnumerator ObstaclesDisappear(bool flag)
    {
        while (speedFlag)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("lethal");
            foreach (GameObject go in gameObjects)
            {
                go.SetActive(!flag);
            }
            yield return null;
        }
    }
    
}
