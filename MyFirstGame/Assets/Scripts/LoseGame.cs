using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseGame : MonoBehaviour
{
    public PlayerCombat player;

    public GameObject loseMenuUI;

    public static bool YouLost = false;


    private void Start()
    {
        loseMenuUI.SetActive(false);
        YouLost = false;
    }

    void Update()
    {
        if (player.dead)
        {
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

