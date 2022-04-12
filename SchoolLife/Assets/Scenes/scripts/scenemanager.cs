using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    //public GameObject panels;
    

    public void exit()
    {
        SceneManager.LoadScene("Library");
        Time.timeScale = 1f;
    }

    public void snakegame()
    {
        SceneManager.LoadScene("librarygame");
        Time.timeScale = 1f;
    }    
    
    //public void nosnakegame()
    //{
    //    panels.SetActive(false);
    //}
}
