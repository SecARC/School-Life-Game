using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryReaction : MonoBehaviour
{
    public FloatValue playerStat;
    public Signal statSignal;

    public void Use(float amountToIncrease)
    {
        if (playerStat.initialValue + amountToIncrease < 100)
        {
            playerStat.initialValue += amountToIncrease;
            statSignal.Call();
        }
        else if (playerStat.initialValue + amountToIncrease >= 100)
        {
            playerStat.initialValue = 100;
            statSignal.Call();
        }
    }
}
