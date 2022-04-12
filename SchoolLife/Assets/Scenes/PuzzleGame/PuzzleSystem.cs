using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleSystem : MonoBehaviour
{
    public int count;

    public Image timerImage;
    public Text timerText;
    public float duration;
    private float currentTime;
    public Text EndText;
    public Text counterText;

    public GameObject StartPanel;
    public GameObject EndPanel;

    public AutoSaveScript manager;
    public CheckResult chkrslt;
    public FloatValue playerKnowledge;

    public SceneName counter;

    void Start()
    {
        Stop();
        counter.ScreenNumber = 0;
        currentTime = duration;
        timerText.text = currentTime.ToString();
        counterText.text = "Score: 0";
        StartCoroutine(UpdateTime());
    }

    private void Update()
    {
        counterText.text = "Score: " + counter.ScreenNumber.ToString();
        if(counter.ScreenNumber == 10)
        {
            Stop();
            count = 1;
            checkCounter();
            counter.ScreenNumber = 0;
        }
    }

    private IEnumerator UpdateTime()
    {
        while (currentTime >= 0)
        {
            timerImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
            if (currentTime == 0)
            {
                Stop();
                count = 2;
                checkCounter();
            }
        }
        yield return null;
    }

    private void checkCounter()
    {
        if (count == 1)
        {
            EndText.text = "Congratulations!!! You Win";
            Win();
            EndPanel.SetActive(true);
        }
        else if (count == 2)
        {
            EndText.text = "Game Over";
            Lose();
            Stop();
            EndPanel.SetActive(true);
        }
    }
    public void Stop()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        StartPanel.SetActive(false);
        if (playerKnowledge.initialValue >= 0 && playerKnowledge.initialValue < 33)
        {
            duration = 100;
            Time.timeScale = 1f;
        }
        else if (playerKnowledge.initialValue >= 33 && playerKnowledge.initialValue < 66)
        {
            duration = 200;
            Time.timeScale = 1f;
        }
        else if (playerKnowledge.initialValue >= 66 && playerKnowledge.initialValue <= 100)
        {
            duration = 300;
            Time.timeScale = 1f;
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("School");
    }

    public void Win()
    {
        chkrslt.win();
    }

    public void Lose()
    {
        chkrslt.lose();
    }
}
