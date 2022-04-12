using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AutoSaveScript manager;
    public SceneName number;
    public VectorValue playerPosition;
    Vector3 position;

    public void PlayGame()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(number.ScreenNumber);
        manager.LoadScriptables();
        position = new Vector3(0f, 0f, -8.84f);
        playerPosition.initialValue = position;
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Debug.Log("Closed game");
        Application.Quit();
    }
}
