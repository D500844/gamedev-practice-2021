using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Start()
    {
        Invoke("Kill", 3f);
    }
    void Kill()
    {
        Destroy(gameObject);
    }
}
