using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrackMove : MonoBehaviour {

    public CharacterController moveController;
    public float moveSpeed = 10.0f;
    Vector3 moveDirection = new Vector3(0.0f, 0.0f, -1.0f);
    // Use this for initialization
    void Start () {
        moveController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        moveController.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (CheckOutofSight())
        {

            DeActivate();
        }

    }



    bool CheckOutofSight()
    {
        if (transform.position.z <= -121.6f)
            return true;
        return false;
    }

    void DeActivate()
    {
        gameObject.SetActive(false);
        transform.parent = transform.parent.parent.GetChild(2);
    }
    
}
