using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Game");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Menu");
    }

    public void PlayDie()
    {
        Time.timeScale = 0f;
        Panel.SetActive(true);
    }
}
