using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    private int[] result, correctCombo;
    // Start is called before the first frame update
    void Start()
    {
        result = new int[] {0, 0, 0};
        correctCombo = new int[] {3, 4, 5};
        Rotate.Rotated += CheckResults;
    }

    void CheckResults(string wheelName, int number) 
    {
        switch (wheelName)
        {
            case "wheel1":
                result[0] = number;
                break;
            case "wheel2":
                result[1] = number;
                break;
            case "wheel3":
                result[2] = number;
                break;
        }
        if (result[0] == correctCombo[0] && result[1] == correctCombo[1] && result[2] == correctCombo[2])
        {
            Debug.Log("Open");
        }
    }
    void OnDestroy() {
        Rotate.Rotated -= CheckResults;    
    }
}
