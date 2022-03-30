using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundChange : MonoBehaviour
{
    [Header("BGTag1 and Default Sprites")]
    [SerializeField] float turnBackOnIn = 3f;
    [SerializeField] float turnOffIn = 2f;
    //[SerializeField] bool spriteOnByDefault = false;
    [SerializeField] bool doWantTurnOff = false;
    [SerializeField] bool doWantTurnBackOn = false;
    //[SerializeField] bool changeScrollSpeed = false;
    [SerializeField] GameObject DockOn;
    [SerializeField] GameObject WaterOn;
    //SpriteScroller spriteScroller;

    [Header("\b")]
    [Header("BGTag2 Sprites")]
    [SerializeField] GameObject spriteToTurnOn;
    [SerializeField] GameObject secondSpriteToTurnOn;
    [SerializeField] GameObject thirdSpriteToTurnOn;
    float justASecond = 2f;

    [Header("Choose Sprite")]
    public SpriteRenderer spriteRend;
    public SpriteRenderer Street;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //////////////// TAG 1
        ////////////////
        
        if (other.tag == "BGtag1")
        {

            Street.enabled = false;
            DockOn.SetActive(true);
            WaterOn.SetActive(true);
            //spriteRend.enabled = spriteOnByDefault;

            //if (changeScrollSpeed == true)
            //{
            //    spriteScroller.AddMovementDown();
            //}
            if (doWantTurnBackOn == true)
            {
                Invoke("TurnItBackOn", turnBackOnIn);
            }

            if (doWantTurnOff == true)
            {
                StartCoroutine(TurnItBackOff());
            }
        }
       
        /////////////// TAG 2
        ///////////////
        
        if (other.tag == "BGtag2")
        {
            spriteToTurnOn.SetActive(true);
            Invoke("TurnItOnInASecond", justASecond);
        }
    }

    public void TurnItBackOn()
    {
        spriteRend.enabled = true;
    }

    public IEnumerator TurnItBackOff()
    {
        yield return new WaitForSeconds(turnOffIn);
        spriteRend.enabled = false;
    }

    public void TurnItOnInASecond()
    {
        secondSpriteToTurnOn.SetActive(true);
        thirdSpriteToTurnOn.SetActive(true);
    }
}


