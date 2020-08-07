using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    public CinemachineBrain cine;
    //public PauseMenu pauseMenu;
    //public PlayerMove playerMove;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cine.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (!PauseGame.GameIsPaused)  && (!LoseGame.YouLost) && (!WinGame.YouWin))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cine.enabled = true;
            //playerMove.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.Escape) || PauseGame.GameIsPaused || LoseGame.YouLost || WinGame.YouWin)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cine.enabled = false;
            //playerMove.enabled = false;

        }
    }
}
