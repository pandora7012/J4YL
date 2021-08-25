using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StoreElement : MonoBehaviour
{
    public Character character;
    public int ID; 
    public Image avatar;

    
    public void setDATA(Character character)
    {
        this.character = character;
        //avatar.SetNativeSize();

        if (character.trigger)
            avatar.sprite = character.avaON;
        else
            avatar.sprite = character.avaOFF;
    }

    public void AvatarOnClicked()
    {
        StoreManagement.Instance.setCharacter(character.character);
        if (character.trigger)
        {
            PlayerPrefs.SetInt("Data", ID);
        }
    }

}
