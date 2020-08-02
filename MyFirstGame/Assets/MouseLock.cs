using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    public CinemachineBrain cine;
    //public PlayerMove playerMove;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cine.enabled = true;
            //playerMove.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cine.enabled = false;
            //playerMove.enabled = false;

        }
    }
}
