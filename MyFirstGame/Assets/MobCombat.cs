using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCombat : MonoBehaviour
{
    public Animator animator;
    public EnemyControl enemyControl;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        enemyControl = GetComponent<EnemyControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;


        // mob hurt animation
        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            die();
            Invoke("destroy", 5f);
        }

    }


    void destroy()
    {
        Destroy(gameObject);
    }


    void die()
    {
        Debug.Log(name + " died.");

        // die animation
        animator.SetBool("dead", true);

        // disable enemy




        //turn off script
        enemyControl.enabled = false;
    }
}