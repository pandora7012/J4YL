using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ScoreBoard : MonoBehaviour
{
    public static bool gameOver = false;
    [SerializeField] private GameObject scoreBoard;

    private void Start()
    {
        gameOver = false;
    }

    private void Update()
    {
        if (gameOver == true)
        {
            scoreBoard.active = true;
            Time.timeScale = 1f;
        }
        else scoreBoard.active = false; 
    }

    public void exit()
    {
        Time.timeScale = 1f;
        gameOver = false;
        FindObjectOfType<AudioManager>().Play("Background");
        SceneManager.LoadScene("GamePlay");
    }
}
