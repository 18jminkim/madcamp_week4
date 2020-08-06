using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // mob animator
    public Animator animator;

    // hitbox collider
    public Collider mobCollider;

    // attack damages
    public int dmg1 = 30;
    public int dmg2 = 40;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        mobCollider = GetComponent<Collider>();
        mobCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Stab") || animator.GetCurrentAnimatorStateInfo(0).IsName("Smash"))
        {
            mobCollider.enabled = true;
        }
        else
        {
            mobCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {

        if (trigger.tag == "PlayerHurtbox") // collided with a hostile mob.
        {
            Debug.Log(name + " hit " + trigger.name);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Stab")  )
            {
                trigger.GetComponentInParent<PlayerCombat>().takeDamage(dmg1);

            }
            else
            {
                trigger.GetComponentInParent<PlayerCombat>().takeDamage(dmg2);
            }
        }
    }
}
