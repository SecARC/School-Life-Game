using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryPanel : MonoBehaviour
{
    public movement2 playerMovement;
    public GameObject character;
    public GameObject dialogPanel;

    void Update()
    {
        if (playerMovement.icame == true)
        {
            OpenDialogPanel();
        }

        if (playerMovement.icame == false)
        {
            CloseDialogPanel();
        }
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
