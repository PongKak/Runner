using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMove : MonoBehaviour {

    public CharacterController moveController;
    // Update is called once per frame
    public float moveSpeed = 10.0f;
    static float sizeofTrack = 121.6f;
    Vector3 moveDirection = new Vector3(0.0f, 0.0f, -1.0f);
    Vector3 startPosition = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 nextPosition = new Vector3(0.0f, 0.0f, sizeofTrack);

    enum Track
    {
        Cur_Track = 0,
        Next_Track,
        TrackPool,
    }

    void Start()
    {
        moveController = GetComponent<CharacterController>();
        transform.position = nextPosition;
    }

    void Update () {
        moveController.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (CheckOutofSight())
        {
            DeActivate();
        }
        



    }

    bool CheckOutofSight()
    {
        if (transform.position.z <= -sizeofTrack)
            return true;
        return false;
    }

    void DeActivate()
    {
        transform.position = nextPosition;
        gameObject.SetActive(false);
        transform.parent = transform.parent.parent.GetChild((int)Track.TrackPool);
    }
    
}
