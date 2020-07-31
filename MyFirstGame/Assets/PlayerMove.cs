using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody characterRb;
    public Collider characterCol;


    // movement
    public float runSpeed = 1f;
    public bool movable = true;


    // rotation
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // animations
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        characterRb = GetComponent<Rigidbody>();
        characterCol = GetComponent<Collider>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        move();
    }



    // movement
    private void move()
    {
        // translation
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;
        transform.Translate(direction * runSpeed * Time.deltaTime, Space.World);


        //rotation
        if (direction.normalized.magnitude > 0f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //run = true;
            animator.SetBool("run", true);
        }
        else
        {
            //run = false;
            animator.SetBool("run", false);
        }



    }
}
