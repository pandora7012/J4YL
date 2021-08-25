using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public static bool pause = false;
    [SerializeField] private GameObject pauseMenuUI; 
    // Update is called once per frame
    void Update()
    {
        if (pause == false)
            resume();
        else
            pauseGame();
    }

    public void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        pause = true;
        Time.timeScale = 0; 
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        pause = false;  
    }

    public void pauseButton()
    {
        pause = true; 
    }

    public void exitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        pause = false;
    }

    public void viberation()
    {

    }

    public void restartPlay()
    {
        resume();
        SceneManager.LoadScene("GamePlay");
    }

    public void musicSet()
    {
       
    }
}
