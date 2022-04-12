using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGameMultiplexer : MonoBehaviour
{
    public List<questions> questionsList;
    public questions currentQuestion;
    public GameObject box;
    public Text quesText;
    private int totalScore;
    private int currentScore;
    public Text totalScoreText;
    public Text currentScoreText;
    public Image timerImage;
    public Text timerText;
    private float duration;
    private float currentTime;
    private bool game;
    public GameObject startPanel;

    public FloatValue playerKnowledge;

    public WordGameAdmin admin;
    int randomQues;
    public InputField ýnput;

    void Start()
    {
        admin.stop();        
        timerText.text = currentTime.ToString();
        totalScore = 0;
        currentScoreText.text = " ";
        quesGive();
        StartCoroutine(UpdateTime());        
    }

    void Update()
    {
        totalScoreText.text = totalScore.ToString();
        currentScoreText.text = currentScore.ToString();
        admin.setScore(totalScore);
    }

   public void quesGive()
    {
        if (questionsList.Count > 0)
        {
            foreach (Transform Object in this.transform)
            {
                Destroy(Object.gameObject);
            }
            randomQues = Random.Range(0, questionsList.Count);
            currentQuestion.Question = questionsList[randomQues].Question;
            currentQuestion.Answer = questionsList[randomQues].Answer;
            for (int i = 0; i < currentQuestion.Answer.Length; i++)
            {
                GameObject Multiplexer = Instantiate(box, transform);
                Multiplexer.transform.Find("QuestionText").GetComponent<Text>().text = currentQuestion.Answer[i].ToString();
                questionsList[randomQues].NotOpened.Add(Multiplexer.transform.Find("QuestionText").GetComponent<Text>());
                quesText.text = currentQuestion.Question;
                Multiplexer.transform.Find("QuestionText").gameObject.SetActive(false);
            }
            currentQuestion.NotOpened = questionsList[randomQues].NotOpened;
            currentScore = 100 * currentQuestion.Answer.Length;
        }
        else if (questionsList.Count == 0)
        {
            admin.Invoke("endGame", 1f);
        }
    }

    public void getLetter()
    {
        if (currentQuestion.NotOpened.Count > 0)
        {
            int randomLetter = Random.Range(0, currentQuestion.NotOpened.Count);
            currentQuestion.NotOpened[randomLetter].gameObject.SetActive(true);
            currentQuestion.NotOpened.RemoveAt(randomLetter);
            currentScore = currentScore - 100;
        }
        else
        {
            Debug.Log("You win");
            questionsList.RemoveAt(randomQues);
            Invoke("quesGive", 1.5f);
        }
    }

    public void directGuess()
    {
        if (ýnput.text.ToLower()== currentQuestion.Answer || ýnput.text.ToUpper()==currentQuestion.Answer)
        {
            Debug.Log("You win");
            questionsList.RemoveAt(randomQues);
            foreach (Text texts in currentQuestion.NotOpened)
            {
                texts.gameObject.SetActive(true);
            }
            totalScore = totalScore + currentScore;
            Invoke("quesGive", 1.5f);
        }
        else
        {
            Debug.Log("Wrong guess");
            totalScore -= 50;
        }
    }

    private IEnumerator UpdateTime()
    {
        while (currentTime >= 0)
        {
            timerImage.fillAmount = Mathf.InverseLerp(0,duration,currentTime);
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
            if (currentTime == 0)
            {
                admin.Invoke("endGame", 0.5f);
            }
        }
        yield return null;
    }

    public void startGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
        if (playerKnowledge.initialValue >= 0 && playerKnowledge.initialValue < 33)
        {
            duration = 80;
            Time.timeScale = 1f;
        }
        else if (playerKnowledge.initialValue >= 33 && playerKnowledge.initialValue < 66)
        {
            duration = 120;
            Time.timeScale = 1f;
        }
        else if (playerKnowledge.initialValue >= 66 && playerKnowledge.initialValue <= 100)
        {
            duration = 180;
            Time.timeScale = 1f;
        }
        currentTime = duration;
    }
}

[System.Serializable]
public class questions{
    public string Question;
    public string Answer;
    public List<Text> NotOpened;

    public questions(string question, string answer, List<Text> notOpened)
    {
        Question = question;
        Answer = answer;
        NotOpened = notOpened;
    }    
}