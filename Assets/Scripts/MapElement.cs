using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapElement : MonoBehaviour
{
    public MapPK map; 
    public int ID;
    public Image avatar; 

    public void set(MapPK map)
    {
        this.map = map;
        avatar.sprite = map.ava;
    }
    public void AvatarOnClick()
    {
        StoreManagement.Instance.setMap(map.ava);
        PlayerPrefs.SetInt("MAP", ID);
    }
}
