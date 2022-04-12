using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/PlayerInventory")]
[System.Serializable]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
}
