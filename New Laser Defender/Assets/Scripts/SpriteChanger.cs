using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite newSprite;


    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}
