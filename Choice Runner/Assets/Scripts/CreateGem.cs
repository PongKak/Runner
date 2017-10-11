using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGem : MonoBehaviour {

    public GameObject Gem;

    public float GenerateTime = 5.0f;
    public float dt = 0.0f;
    int index = 0;
    int sizeofPool = 10;
    GameObject[] gemPool;


	// Use this for initialization
	void Start () {
        Create();
    }
	
	// Update is called once per frame
	void Update () {
        dt += Time.deltaTime;

        if(dt >= GenerateTime)
        {
            dt = 0.0f;
            Generate();
        }
	}

    void Create()
    {
        gemPool = new GameObject[sizeofPool];

        for (int i = 0; i < 10; i++)
        {
            gemPool[i] = Instantiate(Gem) as GameObject;
            gemPool[i].transform.parent = transform;
            gemPool[i].transform.position = transform.position;
            gemPool[i].SetActive(false);
        }
    }

    void Generate()
    {
        gemPool[index].SetActive(true);
        index = (index + 1) % sizeofPool;
    }

}
