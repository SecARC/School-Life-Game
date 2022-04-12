using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketPanel : MonoBehaviour
{
    public movement2 playerMovement;
    public GameObject character;
    public GameObject dialogPanel;
    public GameObject marketPanel;

    void Update()
    {
        if (playerMovement.ýcame == true)
        {
            OpenDialogPanel();
        }

        if (playerMovement.ýcame == false)
        {
            CloseDialogPanel();
        }
    }

    public void OpenMarketPanel()
    {
        marketPanel.SetActive(true);
    }

    public void CloseMarketPanel()
    {
        marketPanel.SetActive(false);
    }

    public void OpenDialogPanel()
    {
        dialogPanel.SetActive(true);
    }

    public void CloseDialogPanel()
    {
        dialogPanel.SetActive(false);
    }
}
