using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance; 

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Background");
    }
    public void Play(string name)
    {
       Sounds s =  Array.Find(sounds, sounds => sounds.Name == name);
        if (s == null)
            return;
       s.source.Play();
    }

    public void Mute(string name)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.Name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
}
