using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    
    public GameObject platforms;
    static public int initPosPlat = 5 ;
    static public int gasp = 6; 
    // Start is called before the first frame update
    void Start()
    {
        initPosPlat = 5;
        gasp = 6;
        instanPlatform();
        for(int i = 0; i < 3; i++)
        {
            instanPlatform(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.posOfCol - initPosPlat < 15)
        {
            instanPlatform();
            instanPlatform();
        }
    }

     public void instanPlatform()
    {
        Instantiate(platforms, new Vector2(Random.Range(-3f,3f), initPosPlat), Quaternion.identity);
        initPosPlat -= gasp; 
    }

    
}
