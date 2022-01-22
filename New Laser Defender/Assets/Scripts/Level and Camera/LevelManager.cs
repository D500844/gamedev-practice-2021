using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    AudioPlayer audioPlayer;
    PauseManager pauseManager;
    //[SerializeField] float sceneLoadDelay = 2f;

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu()
    {
        PauseManager.paused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadCharSelect()
    {
        SceneManager.LoadScene("CharSelect");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadOptionMenu()
    {
        PauseManager.paused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene("OptionMenu");
    }

    //IEnumerator WaitAndLoad(string sceneName, float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    SceneManager.LoadScene(sceneName);
    //}
}
