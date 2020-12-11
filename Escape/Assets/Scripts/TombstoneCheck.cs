using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombstoneCheck : MonoBehaviour
{
    public GameObject player, reaper;
    public string belongingTag;
    public bool atPeace;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        reaper = GameObject.FindGameObjectWithTag("Enemy");
        atPeace = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == belongingTag)
        {
            reaper.GetComponent<EnemyAI>().trigger = false;
            atPeace = true;
        }
        if (other.CompareTag("Player") && !atPeace)
        {
            reaper.GetComponent<EnemyAI>().trigger = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            reaper.GetComponent<EnemyAI>().trigger = false;
        }
    }
}
