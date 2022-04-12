using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public List<GameObject> error_images;
    public GameObject game_over_popup;

    int lives_ = 0;
    int error_number_ = 0;

    void Start()
    {
        lives_ = error_images.Count;
        error_number_ = 0;
    }

    private void WrongNumber()
    {
        if(error_number_ < error_images.Count)
        {
            error_images[error_number_].SetActive(true);
            error_number_++;
            lives_--;
        }
        CheckForGameOver();
    }

    private void CheckForGameOver()
    {
        if (lives_ <= 0)
        {
            GameEvents.OnGameOverMethod();
            game_over_popup.SetActive(true);
        }
    }

    private void OnEnable()
    {
        GameEvents.OnWrongNumber += WrongNumber;
    }

    private void OnDisable()
    {
        GameEvents.OnWrongNumber -= WrongNumber;
    }
}
