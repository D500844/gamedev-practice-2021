using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("ReloadScene", 2f);
        }
    }

    void ReloadScene()
    {
        Debug.Log("Fishy Titties");
        SceneManager.LoadScene(0);
    }
}
