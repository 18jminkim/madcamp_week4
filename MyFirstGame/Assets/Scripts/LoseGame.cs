using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseGame : MonoBehaviour
{
    public PlayerCombat player;

    public GameObject loseMenuUI;

    public static bool YouLost = false;

    public AudioManage audioManage;


    private void Start()
    {
        player = FindObjectOfType<PlayerCombat>();
        loseMenuUI.SetActive(false);
        YouLost = false;
        audioManage = FindObjectOfType<AudioManage>();
    }

    void Update()
    {
        
        if (player.dead)
        {
            //audioManage.Stop("BossTheme");
            Debug.Log("Player Died");
            loseMenuUI.SetActive(true);
            YouLost = true;
            
        }
        
    }


    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}

