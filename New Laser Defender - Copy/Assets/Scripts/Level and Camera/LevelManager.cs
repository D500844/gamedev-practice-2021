using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    AudioPlayer audioPlayer;
    PauseManager pauseManager;

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
        Time.timeScale = 0.3f;
        Invoke("fuckingBullshit", 1f);
    }

    private void fuckingBullshit()
    {
        Time.timeScale = 1f;
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
}
