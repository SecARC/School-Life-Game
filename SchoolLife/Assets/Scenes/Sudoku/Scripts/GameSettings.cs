using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public enum EGameMode
    {
        NOT_SET,
        EASY,
        NORMAL,
        HARD
    }

    public static GameSettings Instance;

    private void Awake()
    {
        _Paused = false;
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(this);
    }

    private EGameMode _GameMode;
    private bool _Paused = false;

    public void SetPaused(bool paused) { _Paused = paused; }

    public bool GetPaused() { return _Paused; }

    void Start()
    {
        _GameMode = EGameMode.NOT_SET;
    }
    
    public void SetGameMode(EGameMode mode)
    {
        _GameMode = mode;
    }

    public void SetGameMode(string mode)
    {
        if(mode == "Easy") SetGameMode(EGameMode.EASY);
        else if(mode == "Normal") SetGameMode(EGameMode.NORMAL);
        else if(mode == "Hard") SetGameMode(EGameMode.HARD);
        else SetGameMode(EGameMode.NOT_SET);
    }
    
    public string GetGameMode()
    {
        switch (_GameMode)
        {
            case EGameMode.EASY:
                return "Easy";
            case EGameMode.NORMAL:
                return "Normal";
            case EGameMode.HARD:
                return "Hard";
        }
        Debug.LogError("ERROR: Game Level is not set");
        return " ";
    }
}
