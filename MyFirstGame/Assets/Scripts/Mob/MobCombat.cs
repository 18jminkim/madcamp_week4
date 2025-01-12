﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MobCombat : MonoBehaviour
{
    public Animator animator;
    public EnemyControl enemyControl;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public AudioManage audioManage;



    //public EnemyControl enemyControl;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        enemyControl = GetComponent<EnemyControl>();
        audioManage = FindObjectOfType<AudioManage>();

        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.setMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int damage)
    {
        if ( currentHealth <= 0)
        {
            return;
        }

        audioManage.Play("Hurt");
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);



        // mob hurt animation

        if (currentHealth <= 0)
        {
            die();
            Invoke("destroy", 5f);
        }
        else
        {
            animator.SetTrigger("hurt");

        }

    }



    void destroy()
    {
        Destroy(gameObject);
        //turn off script
        this.enabled = false;
    }


    void die()
    {
        Debug.Log(name + " died.");
        audioManage.Play("MobDead");


        // die animation
        animator.SetBool("dead", true);

        // disable enemy
        enemyControl.enabled = false;
    }
}