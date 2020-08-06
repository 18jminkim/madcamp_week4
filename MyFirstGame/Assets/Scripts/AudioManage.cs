using UnityEngine.Audio;
using System;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class AudioManage : MonoBehaviour
{
    public Sound[] sounds;
    public PlayerCombat player;
    private void Awake()
    {
        foreach(Sound s in sounds)
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
        Play("Theme");
        //switch (SceneManager.GetActiveScene().buildIndex)


    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (player.dead)
            {
                Stop("Theme");
            }
        }

        
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (WinGame.YouWin)
            {
                Stop("Theme");
            }
        }

    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        
         s.source.Play();
     
    }


    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
        
    }


    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return false ;
        }

        return s.source.isPlaying;

    }
}
