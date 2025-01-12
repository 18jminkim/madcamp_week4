﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Knight animator
    public Animator animator;

    // mesh collider of the knight sword
    public Collider swordCol;

    public AudioManage audioManage;

    // attack damages
    public int dmg1 = 20;
    public int dmg2 = 20;
    public int dmg3 = 30;



    // Start is called before the first frame update
    void Start()
    {
        swordCol = GetComponent<Collider>();
        animator = GetComponentInParent<Animator>();
        audioManage = FindObjectOfType<AudioManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsTag("Fury"))
        {
            swordCol.enabled = true;
        }
        else
        {
            swordCol.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider trigger)
    {
        int dmg = 0;
        if (trigger.tag == "MobHurtbox") // collided with a hostile mob.
        {
            Debug.Log("Sword collider: we hit " + trigger.name);
            audioManage.Play("Hurt");
            MobCombat mobCombat = trigger.GetComponent<MobCombat>();
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                dmg = dmg1;
            }
            else
            {
                dmg = dmg3;
            }
            if (mobCombat != null) // not a boss.
            {
                mobCombat.takeDamage(dmg);
            }
            else // is a boss.
            {
                trigger.GetComponent<BossCombat>().takeDamage(dmg);
            }





        }
    }
}
