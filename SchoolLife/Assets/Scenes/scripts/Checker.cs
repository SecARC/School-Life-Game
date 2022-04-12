using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public GameObject geoDoor;
    public GameObject liteDoor;
    public GameObject mathDoor;
    public GameObject peoDoor;
    public GameObject spaceGame;
    public GameObject snakeGame;
    
    public GameObject winPanel;
    public GameObject diePanel;

    public FloatValue playerEnergy;
    public FloatValue playerKnowledge;
    public FloatValue playerHealth;

    public Animator animator;

    private void Update()
    {
        checkEnergy();
        checkWin();
        checkHealth();
    }

    private void checkEnergy()
    {
        if(playerEnergy.initialValue <= 15)
        {
            geoDoor.SetActive(false);
            liteDoor.SetActive(false);
            mathDoor.SetActive(false);
            peoDoor.SetActive(false);
            spaceGame.SetActive(false);
            snakeGame.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void checkWin()
    {
        if (playerKnowledge.initialValue == 100)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void checkHealth()
    {
        if (playerHealth.initialValue >= 1)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
            animator.SetBool("die", true);
            diePanel.SetActive(true);
        }
    }
}
