using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public Animator animator;
    public float lookRadius = 6f;
    // Start is called before the first frame update\

    Transform target;
    NavMeshAgent agent;
    void Start()
    {
        animator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        float distance = Vector3.Distance(target.position, transform.position);

        // player is within distance and mob is movable.
        if (distance <=lookRadius && !(animator.GetCurrentAnimatorStateInfo(0).IsTag("Immovable")))
        {
            agent.SetDestination(target.position);
            animator.SetBool("move", true);
            FaceTarget();
            if (distance <= agent.stoppingDistance){
                //Attack the target
                attack();

               
                

            }
        }
        else // mob is not moving.
        {
            animator.SetBool("move", false);

        }
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

    private void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
    }


    void attack()
    {
        animator.SetTrigger("attack");
    }
}
