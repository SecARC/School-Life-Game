using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{
    public GameObject WinPopUp;
    public Text ClockText;
    private GridSquare counterCheck;

    public FloatValue playerKnowledge;
    public FloatValue playerEnergy;
    public FloatValue playerHappiness;
    public FloatValue playerMoney;
    
    public CheckResult chkrslt;
    public Clock checkTime;

    void Start()
    {
        WinPopUp.SetActive(false);
        ClockText.text = Clock.Instance.GetCurrentTimeText().text;
    }

    public void OnBoardCompleted()
    {
        WinPopUp.SetActive(true);
        ClockText.text = Clock.Instance.GetCurrentTimeText().text;
        if (counterCheck.GetComponent<GridSquare>().counter >= 10 && checkTime.span.Minutes <= 10)
        {
            chkrslt.win();
            
        }
        else if ((counterCheck.GetComponent<GridSquare>().counter >= 5 && counterCheck.GetComponent<GridSquare>().counter < 10) && (checkTime.span.Minutes <= 15 && checkTime.span.Minutes > 10))
        {
            if (playerKnowledge.initialValue + 5 > 100)
            {
                playerKnowledge.initialValue = 100;
            }
            else if (playerKnowledge.initialValue + 5 < 100)
            {
                playerKnowledge.initialValue += 5;
            }

            if (playerHappiness.initialValue - 10 > 0)
            {
                playerHappiness.initialValue -= 10;
            }
            else if (playerHappiness.initialValue - 10 <= 0)
            {
                playerHappiness.initialValue = 0;
            }

            if (playerEnergy.initialValue - 10 > 0)
            {
                playerEnergy.initialValue -= 10;
            }
            else if (playerEnergy.initialValue - 10 <= 0)
            {
                playerEnergy.initialValue = 0;
            }
            playerMoney.initialValue += 5;
        }
        else if(counterCheck.GetComponent<GridSquare>().counter >= 0 && counterCheck.GetComponent<GridSquare>().counter < 5 && (checkTime.span.Minutes > 15))
        {
            chkrslt.lose();
        }
    }

    private void OnEnable()
    {
        GameEvents.OnBoardCompleted += OnBoardCompleted;
    }
    private void OnDisable()
    {
        GameEvents.OnBoardCompleted -= OnBoardCompleted;
    }
}
