using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCPanel : MonoBehaviour
{
    public movement2 playerMovement;
    public GameObject character;
    public GameObject dialogPanel;

    void Update()
    {
        if (playerMovement.pccame == true)
        {
            OpenPCPanel();
        }

        if (playerMovement.pccame == false)
        {
            ClosePCPanel();
        }
    }

    public void OpenPCPanel()
    {
        dialogPanel.SetActive(true);
    }

    public void ClosePCPanel()
    {
        dialogPanel.SetActive(false);
    }

    public void spaceGame()
    {
        SceneManager.LoadScene("SpaceWar");
    }
}
