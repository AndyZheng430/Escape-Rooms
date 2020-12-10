using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position.Set(0f, 0f, 0f);
        Debug.Log(this.transform.position);
    }
}
