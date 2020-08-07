using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void PlayGame(){
       SceneManager.LoadScene(1);
   }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
