using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] UnityEvent OnCompleteEvent;

    SpriteScroller spriteScroller;

    public Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //trigger
        if (other.tag == "Player")
        {
            //
        }
    }
}


