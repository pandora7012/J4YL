using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DATA", menuName = "CREATE/DATA", order = 1)]
public class DATABASE : ScriptableObject
{
    public Character[] characters;
    public MapPK[] maps; 
}

[System.Serializable]
public class Character
{
    public Sprite avaON;
    public Sprite avaOFF;
    public Sprite character;
    public bool trigger = false;
    public int cost; 
}
[System.Serializable]
public class MapPK
{
    public Sprite ava;
    public Sprite mapbg;
    public Sprite platNor;
    public Sprite platBre;
    public Sprite Wall;
}
