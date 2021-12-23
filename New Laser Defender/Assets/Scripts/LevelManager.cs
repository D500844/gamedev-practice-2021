using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    AudioPlayer audioPlayer;
    [SerializeField] float sceneLoadDelay = 2f;

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        //DestroyImmediate(gameObject);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        //Application.Quit();
    }

    //public void LoadOptionsMenu()
    //{
    //    SceneManager.LoadScene("Options Menu");
    //}

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
