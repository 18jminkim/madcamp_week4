﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidingFurySound : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManage>().Play("GlidingFury");
    }
}
