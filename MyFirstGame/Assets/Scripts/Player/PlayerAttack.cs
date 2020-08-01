using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Knight animator
    public Animator animator;

    // mesh collider of the knight sword
    public Collider swordCol;

    // attack damages
    public int dmg1 = 20;
    public int dmg2 = 20;
    public int dmg3 = 30;



    // Start is called before the first frame update
    void Start()
    {
        swordCol = GetComponent<Collider>();
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
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

        if (trigger.tag == "Mob") // collided with a hostile mob.
        {
            Debug.Log("Sword collider: we hit " + trigger.name);
            trigger.GetComponent<MobCombat>().takeDamage(dmg1);

        }
    }
}
