using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarketInventoryManager : MonoBehaviour
{
    [Header("Market Information")]
    public PlayerInventory marketInventory;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject blankkInventorySlot;
    [SerializeField] private GameObject marketPanel;
    public InventoryItem currentItem;
    public FloatValue playerMoney;

    void Start()
    {
        SetTextAndButton("", false);
        MarketMakeInventorySlot();
    }

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            buyButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(false);
        }
    }

    void MarketMakeInventorySlot()
    {
        if (marketInventory)
        {
            for (int i = 0; i < marketInventory.myInventory.Count; i++)
            {
                GameObject templ = Instantiate(blankkInventorySlot, marketPanel.transform.position, Quaternion.identity);
                templ.transform.SetParent(marketPanel.transform);
                MarketSlot newySlot = templ.GetComponent<MarketSlot>();
                if (newySlot)
                {
                    newySlot.Setup(marketInventory.myInventory[i], this);
                }
            }
        }
    }
    public void BuyButtonPressed()
    {
        if (playerMoney.initialValue>=currentItem.value)
        {
            if (!currentItem.unique)
            {
                currentItem.buy();
            }
            else if (currentItem.unique)
            {
                if (currentItem.numberHeld == 0)
                {
                    currentItem.buy();
                }
            }
        }
    }

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        buyButton.SetActive(true);
    }
}
