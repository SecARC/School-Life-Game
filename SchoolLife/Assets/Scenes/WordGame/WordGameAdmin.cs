using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordGameAdmin : MonoBehaviour
{
    public GameObject endPanel;
    public Text endText;
    internal int score;
    
    public CheckResult chkrslt;
    public FloatValue playerKnowledge;

    public void stop()
    {
        Time.timeScale = 0f;
    }

    public WordGameAdmin(int score)
    {
        this.score = score;
    }
   
    public void setScore(int newScore)
    {
        score = newScore;
    }

    public void quitGame()
    {
        SceneManager.LoadScene("School");   
    }

    public void endGame()
    {
        Invoke("stop", 1f);
        if (score < 3000)
        {
            endText.text = "Game Over";
            chkrslt.lose();
        }
        if (score >= 3000)
        {
            endText.text = "You Win";
            chkrslt.win();
        }
        endPanel.SetActive(true);
    }
}
