using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class BackgroundChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //trigger
        if (other.tag == "BGtag1")
        {
            Debug.Log("test2");
        }
    }
}


