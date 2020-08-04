using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public Collider doorCol;


    private void Start()
    {
        doorCol = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collided");
            LoadNextLevel();
        }
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine ( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1) );
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Ani
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
