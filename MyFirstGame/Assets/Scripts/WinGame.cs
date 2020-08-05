﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinGame : MonoBehaviour
{

    public BossCombat greenBoss;
    public BossCombat redBoss;
    public BossCombat purpleBoss;

    public GameObject winMenuUI;
    public AudioManage audioManage;


    public static bool YouWin = false;

    private void Start()
    {
        winMenuUI.SetActive(false);
        YouWin = false;
        audioManage = FindObjectOfType<AudioManage>();
    }


    void Update()
    {
        if (greenBoss.dead && redBoss.dead && purpleBoss.dead)
        {
            Debug.Log("Resume");
            winMenuUI.SetActive(true);
            YouWin = true;
            //audioManage.Play("BattleC");
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

}
