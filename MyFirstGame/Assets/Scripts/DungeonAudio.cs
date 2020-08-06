using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DungeonAudio : MonoBehaviour
{
    public Sound[] sounds;
    //public BossCombat boss1, boss2, boss3;
    public PlayerCombat player;





    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;


        }
    }


    void Start()
    {
        player = FindObjectOfType<PlayerCombat>();
        Play("DungeonTheme");
    }

    private void Update()
    {
        if (player.dead)
        {
            Stop("DungeonTheme");
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }


    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();

    }
}
