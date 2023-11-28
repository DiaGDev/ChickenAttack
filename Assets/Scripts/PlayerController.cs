using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform gunTransform;

    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    private float activeMoveSpeed;
    public float dashSpeed;
    private float dashLength = .5f,dashCooldown=3f;

    private float dashCounter;
    public float dashCoolCounter;

    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Dash;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;

    }

    void Update()
    {

        movement.x = 0;
        movement.y = 0;

        if (Input.GetKey(Left))
        {
            movement.x += -1;
        }
        if (Input.GetKey(Right)) 
        {
            movement.x += 1; 
        }
        if (Input.GetKey(Down)) 
        { 
            movement.y += -1;
        }
        if (Input.GetKey(Up)) 
        {
            movement.y += 1;
        }

        movement.Normalize();
        rb.velocity = movement * activeMoveSpeed;
        gunTransform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(movement.y, movement.x));
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);



        if (Input.GetKeyDown(Dash))
        {
            Debug.Log("dash has been pressed");
            if(dashCoolCounter<=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter>0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }


    }
