using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepPanel : MonoBehaviour
{
    public movement2 playerMovement;
    public GameObject character;
    public GameObject dialogPanel;

    void Update()
    {
        if (playerMovement.sleep == true)
        {
            OpenSleepPanel();
        }

        if (playerMovement.sleep == false)
        {
            CloseSleepPanel();
        }
    }

    public void OpenSleepPanel()
    {
        dialogPanel.SetActive(true);
    }

    public void CloseSleepPanel()
    {
        dialogPanel.SetActive(false);
    }
}
