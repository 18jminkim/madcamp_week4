using System.Collections;
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

    public Animator transition;
    public float transitionTime = 1f;


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
            StartCoroutine(LoadScene(winMenuUI));
            YouWin = true;
            //audioManage.Play("BattleC");
        }
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
