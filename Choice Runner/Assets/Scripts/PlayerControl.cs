using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    CharacterController characterController;
	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();		

	}


    public float moveSpeed = 10.0f;
    public float gravity = -20.0f;
    public float jumpSpeed = 100.0f;
    public float yVelocity = 0.0f;

    bool jumped = false;

	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(x, 0, 0);

        moveDirection *= moveSpeed;


        if (characterController.isGrounded == true)
        {
            yVelocity = 0.0f;
            gravity = 0.0f;

            jumped = false;
            
        }

        if (Input.GetButtonDown("Jump") && jumped == false)
        {
            gravity = -20.0f;
            yVelocity = jumpSpeed;

            if (jumped == false)
            {
                jumped = true;
            }
        }

        yVelocity += gravity * Time.deltaTime;
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
        

    }
}
