using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{
    public bool[] checkPoints;
    public GameObject[] tombs; 
    public Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        checkPoints = new bool[] {false, false, false};
        tombs = GameObject.FindGameObjectsWithTag("tomb");
        coll = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tombs[0].AddComponent<TombstoneCheck>().atPeace) 
        {
            checkPoints[0] = true;
        }
        if (tombs[1].AddComponent<TombstoneCheck>().atPeace) 
        {
            checkPoints[1] = true;
        }
        if (tombs[2].AddComponent<TombstoneCheck>().atPeace) 
        {
            checkPoints[2] = true;
        }
        if (checkPoints[0] && checkPoints[1] && checkPoints[2])
        {
            coll.isTrigger = true;
        }
    }
}
