using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{

    [SerializeField] private Vector3 movement = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Client]
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) { return; }

        //transform.Translate(movement);
        CmdMove();
    }

    [Command]
    private void CmdMove()
    {
        RpcMove();
    }

    [ClientRpc]
    private void RpcMove()
    {
        transform.Translate(movement);
    }
}
