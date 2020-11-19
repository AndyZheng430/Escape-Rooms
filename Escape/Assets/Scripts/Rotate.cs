using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    private int numbershown;

    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
        numbershown = 0;
    }

    private void OnMouseDown() {
        if (coroutineAllowed) 
        {
            StartCoroutine ("RotateWheel");
        }
    }
    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;
        for (int i = 0; i <= 11; i++) 
        {
            transform.Rotate(new Vector3(-3f, 0f, 0f));
            yield return new WaitForSeconds(0.01f);
        }
        coroutineAllowed = true;
        numbershown += 1;
        if(numbershown > 9)
        {
            numbershown = 0;
        }
        Debug.Log(numbershown);
        Rotated(name, numbershown);
    }
}
