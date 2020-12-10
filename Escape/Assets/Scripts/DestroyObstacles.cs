using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    
public Transform handCon;
public string objName;
     void OnMouseDown() {
        if(handCon.transform.Find(objName))
            {      
                Destroy(gameObject);
            }
        }
     }
