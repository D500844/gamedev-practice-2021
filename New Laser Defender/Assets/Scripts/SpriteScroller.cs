using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteScroller : MonoBehaviour
{

    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;
    [SerializeField] UnityEvent OnCompleteEVent;
    
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
