using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{ 
    void OnTriggerEnter2d(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("You Finished");
        }
    }
}
