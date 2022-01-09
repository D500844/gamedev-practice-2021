using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundChange : MonoBehaviour
{
    public SpriteRenderer spriteRend;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BGtag1")
        {
            Debug.Log("test2");
            spriteRend.enabled = false;
            Invoke("TurnItBackOn", 3f);
            StartCoroutine(TurnItBackOff());
        }
    }

    public void TurnItBackOn()
    {
        spriteRend.enabled = true;
    }

    public IEnumerator TurnItBackOff()
    {
        yield return new WaitForSeconds(4f);
        spriteRend.enabled = false;
    }
}


