using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    
    void Start()
    {
        transform.position = new Vector3(0, 5 - PlayerPrefs.GetInt("highScore") * PlatformManager.gasp - 3, 0);
    }

    
}
