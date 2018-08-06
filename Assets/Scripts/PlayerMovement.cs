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

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        //restricting control. only after camera animation, player can move
        if (Time.time < animationDuration)
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

        //Z forward and background 
        controller.Move(moveVector * Time.deltaTime);
    }


    public void SetSpeed(float modifyer)
    {
        speed = 5.0f + modifyer;
    }

    //called when the player hit something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if collide with something infront z
        if (hit.point.z > transform.position.z + controller.radius)
        {
            Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Coin(Clone)")
        {
            Destroy(other.gameObject);
            GM.coinTotal += 1; //coin score count incremented here

        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

}
