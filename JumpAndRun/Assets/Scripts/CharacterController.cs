using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Animator animator;
    public float speed = 5;
    public float jumpForce = 10;

    public bool grounded;
    
    enum MovingDirection
    {
        Left,
        Right
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(1f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-1f);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);         // Vector2.up
        }
    }

    void Move(float direction)
    {
        animator.SetBool("Walking", true);
            
        Vector3 myPosition = transform.position;
        Vector3 myScale = transform.localScale;
        
        myPosition.x = myPosition.x + (speed * Time.deltaTime) * direction;  
        myScale.x = 1 * direction;   
        
        // if (direction == MovingDirection.Right)
        // {
        //     myPosition.x = myPosition.x + (speed * Time.deltaTime);  
        //     myScale.x = 1;    
        // }
        // else
        // {
        //     myPosition.x = myPosition.x + (-speed * Time.deltaTime);
        //     myScale.x = -1;
        // }
        
        transform.position = myPosition;
        transform.localScale = myScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Enter");
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Exit");
        grounded = false;
    }
}












