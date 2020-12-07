using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class LoadScenes : MonoBehaviour {

    [SerializeField] private int loadLevel;

    void OnTriggerEnter(Collider other) {
    if (other.CompareTag ("Player")) {
        SceneManager.LoadScene (loadLevel);
    }
}

} 