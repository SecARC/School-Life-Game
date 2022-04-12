using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceWarAdmin : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject winPanel;
    public GameObject startPanel;
    public CheckResult chkrslt;    

    public void showPanel()
    {
        endPanel.SetActive(true);
        Invoke("stop", 2f);
        chkrslt.spacegamelose();
    }

    public void showPanel2()
    {
        endPanel.SetActive(true);
        Invoke("stop", 2f);
        chkrslt.spacegamewin();
    }

    public void stop()
    {
        Time.timeScale = 0f;
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SpaceWar");
    }

    public void startGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        SceneManager.LoadScene("Home");
    }
}