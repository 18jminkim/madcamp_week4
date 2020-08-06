using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public PlayerMove playerMove;
    public HealthBar healthBar;
    public AudioManage audioManage;

    // entire player transform.
    public Transform playerTransform;

    public int maxHealth = 100;
    public int currentHealth;
    public float knockbackDistance = 0.5f;


    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // gliding fury combo.
    public int noOfClicks = 0;
    float laskClickedTime = 0f;
    public float maxComboDelay = 0.9f;


    public bool dead = false;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        playerTransform = GetComponentInParent<Transform>();

        healthBar.setMaxHealth(maxHealth);
        audioManage = FindObjectOfType<AudioManage>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                attack();
                nextAttackTime = Time.time + 1f / attackRate;
                //audioManage.Play("Hit");
            }

        }
        */

        if (Time.time - laskClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            laskClickedTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                attack();
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        }


    }
    
    public void return1()
    {
        if (noOfClicks >= 2)
        {
            animator.SetTrigger("glidingFury");
        }
        noOfClicks = 0;
    }
    


    public void takeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);



        // player hurt animation
        if (currentHealth <= 0)
        {
            die();
            dead = true;
            this.enabled = false;
            //Invoke("destroy", 5f);
        }
        else
        {
            if (damage >= 40) // serious damage.
            {
                animator.SetTrigger("hurt2");

            }
            else // light damage.
            {
                animator.SetTrigger("hurt1");
                //playerTransform.Translate(-playerTransform.forward * knockbackDistance, Space.Self);
            }
        }
        audioManage.Play("PlayerHurt");

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
        animator.SetTrigger("hurt2");

        // disable player
        playerMove.enabled = false;
    }


    void attack()
    {
        // Play an attack animation
        animator.SetTrigger("attack");
    }

}
