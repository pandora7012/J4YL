using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpriteSystem : MonoBehaviour
{
    
     public GameObject Wall1;
     public GameObject Wall2;
     public GameObject bg;
     public DATABASE data;
   

   
    public Sprite devWall;
    public Sprite devBG;
  
    
    void Update()
    {
        if (MainMenu.devilMode)
        {
            Wall1.GetComponent<SpriteRenderer>().sprite = devWall;
            Wall2.GetComponent<SpriteRenderer>().sprite = devWall;
            bg.GetComponent<SpriteRenderer>().sprite = devBG;
        }
        else
        {
            
            Wall1.GetComponent<SpriteRenderer>().sprite = data.maps[PlayerPrefs.GetInt("MAP")].Wall ;
            Wall2.GetComponent<SpriteRenderer>().sprite = data.maps[PlayerPrefs.GetInt("MAP")].Wall;
            bg.GetComponent<SpriteRenderer>().sprite = data.maps[PlayerPrefs.GetInt("MAP")].mapbg;
        }
    }
}
