using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResult : MonoBehaviour
{
    public FloatValue playerHealth;
    public FloatValue playerEnergy;
    public FloatValue playerHappiness;
    public FloatValue playerKnowledge;
    public FloatValue playerMoney;
    
    public void win()
    {
        if (playerKnowledge.initialValue + 10> 100)
        {
            playerKnowledge.initialValue = 100;
        }
        else if (playerKnowledge.initialValue + 10 < 100)
        {
            playerKnowledge.initialValue += 10;
        }

        if (playerHappiness.initialValue - 10 > 0)
        {
            playerHappiness.initialValue -= 10;
        }
        else if (playerHappiness.initialValue - 10 <= 0)
        {
            playerHappiness.initialValue = 0;
        }

        if (playerEnergy.initialValue - 15 > 0)
        {
            playerEnergy.initialValue -= 15;
        }
        else if (playerEnergy.initialValue - 15 <= 0)
        {
            playerEnergy.initialValue = 0;
        }
        playerMoney.initialValue += 15;
    }

    public void lose()
    {
        if (playerHappiness.initialValue - 20 > 0)
        {
            playerHappiness.initialValue -= 20;
        }
        else if (playerHappiness.initialValue - 20 <= 0)
        {
            playerHappiness.initialValue = 0;
        }

        if (playerEnergy.initialValue - 15 > 0)
        {
            playerEnergy.initialValue -= 15;
        }
        else if (playerEnergy.initialValue - 15 <= 0)
        {
            playerEnergy.initialValue = 0;
        }

        if (playerHealth.initialValue - 10 > 0)
        {
            playerHealth.initialValue -= 10;
        }
        else if (playerHealth.initialValue - 10 <= 0)
        {
            playerHealth.initialValue = 0;
        }
    }

    public void sleep()
    {
        if (playerHealth.initialValue + 10 >= 100)
        {
            playerHealth.initialValue = 100;
        }
        else if (playerHealth.initialValue + 10 < 100)
        {
            playerHealth.initialValue += 10;
        }

        if (playerEnergy.initialValue + 20 >= 100)
        {
            playerEnergy.initialValue = 100;
        }
        else if (playerEnergy.initialValue + 20 < 100)
        {
            playerEnergy.initialValue += 20;
        }

        if (playerKnowledge.initialValue - 5 <= 0)
        {
            playerKnowledge.initialValue = 0;
        }
        else if (playerKnowledge.initialValue -5 > 0)
        {
            playerKnowledge.initialValue -= 5;
        }
    }

    public void spacegamewin()
    {
        if (playerHappiness.initialValue + 25 >= 100)
        {
            playerHappiness.initialValue = 100;
        }
        else if (playerHappiness.initialValue + 25 < 100)
        {
            playerHappiness.initialValue += 25;
        }

        if (playerEnergy.initialValue - 10 > 0)
        {
            playerEnergy.initialValue -= 10;
        }
        else if (playerEnergy.initialValue - 10 <= 0)
        {
            playerEnergy.initialValue = 0;
        }
    }

    public void spacegamelose()
    {
        if (playerHappiness.initialValue + 15 >= 100)
        {
            playerHappiness.initialValue = 100;
        }
        else if (playerHappiness.initialValue + 15 < 100)
        {
            playerHappiness.initialValue += 15;
        }

        if (playerEnergy.initialValue - 10 > 0)
        {
            playerEnergy.initialValue -= 10;
        }
        else if (playerEnergy.initialValue - 10 <= 0)
        {
            playerEnergy.initialValue = 0;
        }
    }
    public void study()
    {
        if (playerKnowledge.initialValue + 20 > 100)
        {
            playerKnowledge.initialValue = 100;
        }
        else if (playerKnowledge.initialValue + 20 < 100)
        {
            playerKnowledge.initialValue += 20;
        }

        if (playerHappiness.initialValue - 20 > 0)
        {
            playerHappiness.initialValue -= 20;
        }
        else if (playerHappiness.initialValue - 20 <= 0)
        {
            playerHappiness.initialValue = 0;
        }

        if (playerEnergy.initialValue - 30 > 0)
        {
            playerEnergy.initialValue -= 30;
        }
        else if (playerEnergy.initialValue - 30 <= 0)
        {
            playerEnergy.initialValue = 0;
        }
    }
}
