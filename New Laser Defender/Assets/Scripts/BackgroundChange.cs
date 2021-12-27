using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] UnityEvent OnCompleteEvent;

    //call bool variable from sprite source

    //check for trigger in update
    //set bool if triggered

    private void OnTriggerEnter2D(Collider2D other)
    {
        //trigger
        if (other.tag == "Player")
        {
            //set bool
        }
    }
}


