using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackManage : MonoBehaviour {


    public GameObject Track;

    public GameObject Cur_Track;
    public GameObject Next_Track;

    GameObject curTrack;
    GameObject nextTrack;

    GameObject[] trackPool;
    int poolIndex = 0;

	// Use this for initialization
	void Start () {
        trackPool = new GameObject[2];
        for(int i=0;i<2;i++)
        {
            trackPool[i] = Instantiate(Track) as GameObject;
            trackPool[i].transform.position = new Vector3(0.0f, -20.0f, 0.0f);
            trackPool[i].SetActive(false);
            trackPool[i].transform.parent = transform.GetChild(2);
        }
        
     }
	
	// Update is called once per frame
	void Update () {		
        
        if(!CheckChild())
        {
            NextToCur();
            CreateNext();
        }
	}
    
    bool CheckChild()
    {
        if(Cur_Track.transform.childCount == 0)
        {
            return false;
        }

        return true;
    }
    
    void NextToCur()
    {
        curTrack = Next_Track.transform.GetChild(0).gameObject;
        curTrack.transform.parent = Cur_Track.transform;
    }

    void CreateNext()
    {
        nextTrack = trackPool[poolIndex];
        poolIndex = (poolIndex + 1) % 2;
        nextTrack.transform.parent = Next_Track.transform;
        nextTrack.SetActive(true);

    }
}
