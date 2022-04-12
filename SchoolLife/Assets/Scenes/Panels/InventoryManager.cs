using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;

    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject bagButton;

    public InventoryItem currentItem;

    public void SetTextAndButton(string description,bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlot()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if (playerInventory.myInventory[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    void OnEnable()
    {
        ClearSlot();
        MakeInventorySlot();
        SetTextAndButton("", false);
        
    }

    public void SetupDescriptionAndButton(string newDescriptionString,bool isButtonUsable,InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.use();
            ClearSlot();
            MakeInventorySlot();
            if (currentItem.numberHeld == 0)
            {
                SetTextAndButton("", false);
            }
        }
    }

    void ClearSlot()
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void CloseButton()
    {
        mainPanel.SetActive(false);
        bagButton.SetActive(true);
    }

    public void OpenButton()
    {
        mainPanel.SetActive(true);
        bagButton.SetActive(false);
    }
}