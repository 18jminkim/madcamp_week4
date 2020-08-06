using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ForestAudio : MonoBehaviour
{
    public Sound[] sounds;
    public BossCombat boss1, boss2, boss3;
    public static AudioManage instance;





    private void Awake()
    {
        /*
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        */
        //DontDestroyOnLoad(gameObject);


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

        Play("BossTheme");
    }

    private void Update()
    {
        if (boss1.dead && boss2.dead && boss3.dead)
        {
            Stop("BossTheme");

            //Play("BattleCleared");
            //Invoke("BattleCleared", 0.5f);

        }
    }

    public void BattleCleared()
    {
        Play("BattleCleared");
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
        s.source.Stop();

    }
}
