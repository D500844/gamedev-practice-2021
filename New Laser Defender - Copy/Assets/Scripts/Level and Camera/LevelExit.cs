using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] bool Finishing1;
    [SerializeField] bool Finishing2;
    [SerializeField] bool Finishing3;
    [SerializeField] bool Finishing4;
    [SerializeField] float levelLoadWait = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if( Finishing1 == true)
        {
            StartCoroutine(LoadVictoryLevel());
        }

        if (Finishing2 == true)
        {
            StartCoroutine(LoadVictoryLevel2());
        }
        if (Finishing3 == true)
        {
            StartCoroutine(LoadVictoryLevel3());
        }

        if (Finishing4 == true)
        {
            StartCoroutine(LoadVictoryLevel4());
        }
    }

    IEnumerator LoadVictoryLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadWait);
        SceneManager.LoadScene("Victory");
    }

    IEnumerator LoadVictoryLevel2()
    {
        yield return new WaitForSecondsRealtime(levelLoadWait);
        SceneManager.LoadScene("Victory2");
    }

    IEnumerator LoadVictoryLevel3()
    {
        yield return new WaitForSecondsRealtime(levelLoadWait);
        SceneManager.LoadScene("Victory3");
    }

    IEnumerator LoadVictoryLevel4()
    {
        yield return new WaitForSecondsRealtime(levelLoadWait);
        SceneManager.LoadScene("Victory4");
    }


}
