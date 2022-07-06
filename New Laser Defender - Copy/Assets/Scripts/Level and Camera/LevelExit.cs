using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour

{
    [SerializeField] float levelLoadWait = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Victory");
    //    StartCoroutine(LoadVictoryLevel());
    }

   // IEnumerator LoadVictoryLevel()
   // {
   //     yield return new WaitForSecondsRealtime(levelLoadWait);
   //     SceneManager.LoadScene("Victory");
   // }


}
