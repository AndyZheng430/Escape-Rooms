using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public GameObject popup;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("turn off text");
            popup.SetActive(false);
        }
    }
    private void OnMouseDown() {
        if ((this.transform.position - player.transform.position).magnitude <= 10) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Left click");
                popup.SetActive(true);
            }
        }
    }
}
