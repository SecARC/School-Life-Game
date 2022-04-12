using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketReaction : MonoBehaviour
{
    public FloatValue playerStat;
    public Signal statSignal;

    public void Buy(float amountToDecrease)
    {
        if (playerStat.initialValue - amountToDecrease >= 0)
        {
            playerStat.initialValue -= amountToDecrease;
            statSignal.Call();
        }
    }
}
