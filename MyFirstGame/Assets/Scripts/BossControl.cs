using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControl : MonoBehaviour
{
    public Animator animator;
    public float walkRadius = Mathf.Infinity;
    public float runRadius = 10f;
    public Transform bossHitbox;
    // Start is called before the first frame update

    Transform target;
    NavMeshAgent agent;
    void Start()
    {
        animator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        //bossHitbox = GetComponentInChildren<BossHitBox>();
        animator.SetTrigger("battlecry");
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        float distance = Vector3.Distance(target.position, bossHitbox.position);

        // player is within distance and mob is movable.
        if (distance <= walkRadius && !(animator.GetCurrentAnimatorStateInfo(0).IsTag("Immovable")))
        {

           
            FaceTarget();
            animator.SetBool("move", true);
            // distance within sprint range.
            if (distance <= runRadius)
            {
                agent.SetDestination(target.position);
                animator.SetBool("sprint", true);
                //animator.SetBool("move", false);

                //Debug.Log(distance);
                if (distance <= agent.stoppingDistance)
                {
                    //Attack the target
                    attack();
                }
            }
            else
            {
                agent.SetDestination(target.position);
                //animator.SetBool("move", true);
                animator.SetBool("sprint", false);
                if (distance <= agent.stoppingDistance)
                {
                    //Attack the target
                    attack();
                }
            }
        }
        else // mob is not moving.
        {
            animator.SetBool("move", false);
            animator.SetBool("sprint", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, walkRadius);

    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    void attack()
    {
        animator.SetTrigger("attack");
    }



}
