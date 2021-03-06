using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointstext;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointstext.text = score.ToString() + "POINT";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

