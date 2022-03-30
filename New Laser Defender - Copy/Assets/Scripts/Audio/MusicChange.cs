using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicChange : MonoBehaviour
{
    [SerializeField] float songLoadWait = 1f;
    static AudioPlayer instance;


    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNewSong());
    }

    IEnumerator LoadNewSong()
    {
        yield return new WaitForSecondsRealtime(songLoadWait);

    }

    
}
