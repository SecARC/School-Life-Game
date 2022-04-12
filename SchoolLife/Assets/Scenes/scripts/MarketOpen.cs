using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketOpen : MonoBehaviour
{
    public GameObject panel;
    public bool opener = false;

    public void MarketInventoryOpener()
    {
        panel.SetActive(true);
        opener = true;
    }
}
