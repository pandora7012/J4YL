using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StoreManagement : MonoBehaviour
{
    public Image character;
    public static StoreManagement Instance;

    public DATABASE data;

    // character select 
    public StoreElement pref;
    public RectTransform content;
    public GameObject CharacterSelectMenu;

    //map select
    public MapElement aps;
    public RectTransform ct;
    public GameObject MapSelectMenu;
    public Image Image;

   
    public void setCharacter(Sprite sprite)
    {
        this.character.sprite = sprite;
        this.character.SetNativeSize();
    }

    public void setMap(Sprite sprite)
    {
        this.Image.sprite = sprite;
        this.Image.SetNativeSize();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
    }

    void Start()
    {
        init();
    }

    private void init()
    {
        gameObject.SetActive(false);
        int size = data.characters.Length; 
        for(int i = 0; i < size; i++)
        {
            StoreElement se = Instantiate(pref, content);
            se.setDATA(data.characters[i]);
            se.ID = i;
        }
        size = data.maps.Length;
        for(int i = 0; i < size; i++)
        {

            MapElement mp = Instantiate(aps, ct);
            mp.set(data.maps[i]);
            mp.ID = i;
        }
        Image.sprite = data.maps[PlayerPrefs.GetInt("MAP")].ava;
    }

    public void changeToSelectMap()
    {
        CharacterSelectMenu.SetActive(false);
        MapSelectMenu.SetActive(true);
    }

    public void changeToSelectCharacter()
    {
        CharacterSelectMenu.SetActive(true);
        MapSelectMenu.SetActive(false);
    }
   
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
