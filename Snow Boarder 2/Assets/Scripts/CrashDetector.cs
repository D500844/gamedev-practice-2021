using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = .5f;
    [SerializeField] ParticleSystem Crashinbutts;
    [SerializeField] AudioClip shippy2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        { 
            Debug.Log("Bad Touch");
            GetComponent<AudioSource>().PlayOneShot(shippy2);
            Invoke("ReloadScene", loadDelay);
            Crashinbutts.Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
