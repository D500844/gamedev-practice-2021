using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpriteScroller : MonoBehaviour
{

    [SerializeField] public Vector2 moveSpeed;
    Vector2 offset;
    Material material;
    SpriteRenderer spriteRenderer;
    //[SerializeField] UnityEvent OnCompleteEVent;

    
   public void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    public void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

    public void AddMovementDown()
    {
        moveSpeed = new Vector2(0, 1);
    }





}
