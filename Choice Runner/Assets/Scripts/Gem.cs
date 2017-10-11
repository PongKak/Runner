using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    public Vector3 moveDirection = new Vector3(0.0f, 0.0f, -1.0f);
    public float moveSpeed = 20.0f;
    CharacterController controller;


	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();        
	}
	
	// Update is called once per frame
	void Update () {

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (transform.position.z <= -20.0f)
        {
            gameObject.SetActive(false);
            transform.position = transform.parent.position;
        }

        if(transform.position.y >= 20.0f)
        {
            gameObject.SetActive(false);
            transform.position = transform.parent.position;
            moveDirection = new Vector3(0.0f, 0.0f, -1.0f);
        }

	}


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        moveDirection = new Vector3(0.0f, 1.0f, 0.0f);
    }
}
