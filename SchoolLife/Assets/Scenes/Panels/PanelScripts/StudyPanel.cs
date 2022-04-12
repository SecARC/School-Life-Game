using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyPanel : MonoBehaviour
{
    public movement2 playerMovement;
    public GameObject character;
    public GameObject dialogPanel;
    public CheckResult chkrslt;
    void Update()
    {
        if (playerMovement.studycame == true)
        {
            OpenDialogPanel();
        }

        if (playerMovement.studycame == false)
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
