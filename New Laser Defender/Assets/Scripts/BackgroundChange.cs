using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] float timeToStart = 3f;
    [SerializeField] float timeToStop = 4f;
    [SerializeField] bool spriteDefault = false;
    public SpriteRenderer spriteRend;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BGtag1")
        {
            Debug.Log("test2");
            spriteRend.enabled = spriteDefault;
            Invoke("TurnItBackOn", timeToStart);
            StartCoroutine(TurnItBackOff());
        }
    }

    public void TurnItBackOn()
    {
        spriteRend.enabled = true;
    }

    public IEnumerator TurnItBackOff()
    {
        yield return new WaitForSeconds(timeToStop);
        spriteRend.enabled = false;
    }
}


