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

    public Animator transition;
    public float transitionTime = 1f;


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
            //loseMenuUI.SetActive(true);
            StartCoroutine(LoadScene(loseMenuUI));
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

    IEnumerator LoadScene(GameObject win)
    {
        //Play Ani
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        win.SetActive(true);

    }
}

