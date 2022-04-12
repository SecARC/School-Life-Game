using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/Items")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public int value;
    public bool unique;
    public bool usable;
    public UnityEvent thisEvent;
    public UnityEvent otherEvent;

    public void use()
    {
        Debug.Log("Using item");
        thisEvent.Invoke();
    }

    public void DecreaseAmount()
    {
        numberHeld--;
        if (numberHeld < 0)
        {
            numberHeld = 0;
        }
    }

    public void buy()
    {
        otherEvent.Invoke();
        Debug.Log("Buying " + itemName);

    }

    public void IncreaseAmount()
    {
        numberHeld++;
    }
}
