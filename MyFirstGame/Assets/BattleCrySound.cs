using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCrySound : StateMachineBehaviour
{
    //public AudioManage audioManage;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManage>().Play("BattleCry");
    }
}
