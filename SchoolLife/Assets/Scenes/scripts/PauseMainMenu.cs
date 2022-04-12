using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMainMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ActivateObject(GameObject obj)
    {
        obj.SetActive(true);
        int y = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(y);
        Time.timeScale = 0f;
    }

    public void DeActivateObject(GameObject obj)
    {
        obj.SetActive(false);
        Time.timeScale = 1f;
    }
}
