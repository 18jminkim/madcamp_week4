using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtbox : MonoBehaviour
{
    public Animator animator;
    public Collider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        playerCollider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") || animator.GetCurrentAnimatorStateInfo(0).IsTag("Immovable"))
        {
            Debug.Log("Not hittable.");
            playerCollider.enabled = false;
            playerCollider.isTrigger = false;
        }
        else
        {
            playerCollider.enabled = true;
            playerCollider.isTrigger = true;
        }


    }
}
