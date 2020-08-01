using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public PlayerMove playerMove;

    // entire player transform.
    public Transform playerTransform;

    public int maxHealth = 100;
    public int currentHealth;
    public float knockbackDistance = 0.5f;


    public float attackRate = 2f;
    float nextAttackTime = 0f;


    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        playerTransform = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }


    }


    public void takeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        currentHealth -= damage;


        // player hurt animation
        if (currentHealth <= 0)
        {
            die();
            Invoke("destroy", 5f);
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
