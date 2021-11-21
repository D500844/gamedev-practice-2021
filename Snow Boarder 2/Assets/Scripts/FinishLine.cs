using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2d(Collider2D other)
    {
        Debug.Log("You Finished!");
    }
}
