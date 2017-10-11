using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Animation : MonoBehaviour {

    public Animator animator;
    public bool isJumped = false;
    CharacterController characterController;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown("space") && isJumped == false)
        {
            animator.SetBool("Jump", true);
            isJumped = true;

        }

        if(characterController.isGrounded == true)
        {
            isJumped = false;
        }

	}
}
