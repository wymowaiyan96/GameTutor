using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

    public Transform lookat;
    private Vector3 startOffset;
    private Vector3 moveVector;
    private float transition;
    private float animationDuration = 2.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

	// Use this for initialization {only at the start}
	void Start () {
       lookat = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookat.position;
    }
             
	
	// Update is called once per frame {constantly happening}
	void Update () {
        moveVector = lookat.position + startOffset;

        //X
        moveVector.x = 0; //camera still in middle

        //Y - camera move only between 3-5 range
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        //continue later video 4
        //if (transition > 1.0f)
        //{
        //    startOffset = transform.position - lookat.position;
        //}

        //else
        //{
        //    Animation when the game begins
        //    transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
        //    transition += Time.deltaTime * 1 / animationDuration;
        //    transform.LookAt(lookat.position + Vector3.up);
        //}


        transform.position = moveVector;
          }
}
