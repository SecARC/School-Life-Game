using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public AutoSaveScript manager;
    public FloatValue playerKnowledge;
    public FloatValue playerEnergy;
    public FloatValue playerHappiness;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        playerKnowledge.initialValue -= 10;
        playerEnergy.initialValue -= 10;
        playerHappiness.initialValue -= 10;

        SceneManager.LoadScene("School");
    }

    public void LoadGame()
    {
        if (playerKnowledge.initialValue >= 0 && playerKnowledge.initialValue < 33)
        {
            LoadHardGame("GameScene");
        }
        else if (playerKnowledge.initialValue >= 33 && playerKnowledge.initialValue < 66)
        {
            LoadNormalGame("GameScene");
        }
        else if (playerKnowledge.initialValue >= 66 && playerKnowledge.initialValue <= 100)
        {
            LoadEasyGame("GameScene");
        }
    }

    public void LoadEasyGame(string name)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.EASY);
        SceneManager.LoadScene(name);
    }

    public void LoadNormalGame(string name)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.NORMAL);
        SceneManager.LoadScene(name);
    }

    public void LoadHardGame(string name)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.HARD);
        SceneManager.LoadScene(name);
    }

    public void ActivateObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void DeActivateObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void SetPause(bool paused)
    {
        GameSettings.Instance.SetPaused(paused);
    }
}
