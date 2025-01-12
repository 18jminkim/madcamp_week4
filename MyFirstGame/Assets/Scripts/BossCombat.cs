﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public Animator animator;
    public BossControl bossControl;
    public int maxHealth = 300;
    public int currentHealth;
    public HealthBar healthBar;
    public bool dead = false;
    public AudioManage audioManage;



    //public EnemyControl enemyControl;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        bossControl = GetComponent<BossControl>();

        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.setMaxHealth(maxHealth);
        audioManage = FindObjectOfType<AudioManage>();

    }

    public void takeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        //audioManage.Play("Hurt");
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);


        // if health 0, kill the boss
        if (currentHealth <= 0)
        {
            die();
            dead = true;
            //Invoke("destroy", 5f);
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

        // die animation
        animator.SetBool("dead", true);

        // disable enemy
        bossControl.enabled = false;
    }
}
