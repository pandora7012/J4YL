using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public Text text;
    static public bool devilMode = false;
    public Sprite sprite1;
    public Sprite sprite2;
    public Image icon;
    public GameObject CharacterUISelect; 
   public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        int hc;
        if (!devilMode)
            hc = PlayerPrefs.GetInt("highScore");
        else
            hc = PlayerPrefs.GetInt("devilHigh");
        string toString = hc.ToString();
        text.text = toString;
        if (devilMode)
        {
            text.color = Color.red;
            icon.sprite = sprite2;
        }

        else {
            
            text.color = Color.white;
                }
    }

    public void changeMode()
    {
        if (devilMode)
            devilMode = false;
        else devilMode = true; 
    }

    public void StoreUI()
    {
        CharacterUISelect.SetActive(true);
    }


}
