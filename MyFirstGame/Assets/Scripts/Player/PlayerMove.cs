using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody characterRb;
    public Collider characterCol;


    // movement
    public bool movable = true;
    public float runSpeed = 1f;


    // sprinting
    public float sprintSpeed = 3f;
    public bool sprinting = false;


    public float buttonCoolerW = 0.5f;
    private int buttonCountW = 0;
    public float buttonCoolerA = 0.5f;
    private int buttonCountA = 0;
    public float buttonCoolerS = 0.5f;
    private int buttonCountS = 0;
    public float buttonCoolerD = 0.5f;
    private int buttonCountD = 0;



    public string lastDown = " ";
    public bool doubleTap = false;



    // rotation
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // roll
    public bool roll;
    public float rollSpeed = 5f;
    public float rollTime = 1f;



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
        doubleW();
        doubleA();
        doubleS();
        doubleD();

        // roll.
        if (Input.GetKeyDown(KeyCode.Space) && (!roll))
        {
            roll = true;
            animator.SetTrigger("roll");
            Invoke("disableRoll", rollTime);
           
        }

        



    }


    private void FixedUpdate()
    {

        move();
    }



    // movement
    private void move()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Immovable"))
        {
            return;
        }

        // translation
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;




        //rotation
        if (direction.normalized.magnitude > 0f && (!roll))
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //run = true;
            animator.SetBool("run", true);


            if (sprinting)
            {
                animator.SetBool("sprint", true);
            }




        }
        else // character not moving
        {
            sprinting = false;
            animator.SetBool("sprint", false);
            animator.SetBool("run", false);
            //Debug.Log("Not moving.");
        }


        if (roll)
        {
            Vector3 facing = transform.forward.normalized;
            //Debug.Log(facing.ToString());
            transform.Translate(facing * rollSpeed * Time.deltaTime, Space.World);

        }
        else if (sprinting)
        {
            transform.Translate(direction * sprintSpeed * Time.deltaTime, Space.World);

        }

        else
        {
            transform.Translate(direction * runSpeed * Time.deltaTime, Space.World);
        }


    }


    private void doubleW()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            buttonCountA = 0;
            buttonCountS = 0;
            buttonCountD = 0;
            if (buttonCoolerW > 0 && buttonCountW == 1/*Number of Taps you want Minus One*/)
            {
                //Has double tapped

                sprinting = true;

            }
            else
            {
                buttonCoolerW = 0.5f;
                buttonCountW += 1;
            }
        }
        if (buttonCoolerW > 0)
        {
            buttonCoolerW -= 1 * Time.deltaTime;
        }
        else
        {
            buttonCountW = 0;
        }
    }

    private void doubleA()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            buttonCountW = 0;
            buttonCountS = 0;
            buttonCountD = 0;


            if (buttonCoolerA > 0 && buttonCountA == 1/*Number of Taps you want Minus One*/)
            {
                //Has double tapped

                sprinting = true;

            }
            else
            {
                buttonCoolerA = 0.5f;
                buttonCountA += 1;
            }
        }
        if (buttonCoolerA > 0)
        {
            buttonCoolerA -= 1 * Time.deltaTime;
        }
        else
        {
            buttonCountA = 0;
        }
    }

    private void doubleS()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttonCountW = 0;
            buttonCountA = 0;
            buttonCountD = 0;
            if (buttonCoolerS > 0 && buttonCountS == 1/*Number of Taps you want Minus One*/)
            {
                //Has double tapped

                sprinting = true;

            }
            else
            {
                buttonCoolerS = 0.5f;
                buttonCountS += 1;
            }
        }
        if (buttonCoolerS > 0)
        {
            buttonCoolerS -= 1 * Time.deltaTime;
        }
        else
        {
            buttonCountS = 0;
        }
    }

    private void doubleD()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            buttonCountW = 0;
            buttonCountA = 0;
            buttonCountS = 0;
            if (buttonCoolerD > 0 && buttonCountD == 1/*Number of Taps you want Minus One*/)
            {
                //Has double tapped

                sprinting = true;

            }
            else
            {
                buttonCoolerD = 0.5f;
                buttonCountD += 1;
            }
        }
        if (buttonCoolerD > 0)
        {
            buttonCoolerD -= 1 * Time.deltaTime;
        }
        else
        {
            buttonCountD = 0;
        }
    }


    private void disableRoll()
    {
        roll = false;
    }



   




}
