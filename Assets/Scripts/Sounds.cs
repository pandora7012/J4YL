using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sounds
{
    public string Name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;

    public bool loop; 
}
