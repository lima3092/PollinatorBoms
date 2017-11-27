using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {

    public float speed = 10f;
    public float movement= 0f;
    private Rigidbody2D rb2d;
    private bool isDead = false;
    private bool landed = false;
    public Transform groundCheckPoint;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        landed = Physics2D.Linecast(transform.position, groundCheckPoint.position, 1 << LayerMask.NameToLayer("Ground"));
         if (Input.GetKey("right") || Input.GetKey("left"))
        {
            movement = Input.GetAxis("Horizontal");
            
            rb2d.velocity = new Vector2(movement * speed, 0);
            anim.SetTrigger("Flap");

            if (movement < 0f)
            {
                transform.localScale = new Vector2(0.4981088f, 0.4981088f);
            } 
            else if (movement > 0f)
            {
                transform.localScale = new Vector2(-0.4981088f, 0.4981088f);
            }
        }
        else if (Input.GetKey("up") || Input.GetKey("down"))
        {
            movement = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector2(0, movement * speed);
            anim.SetTrigger("Flap");
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }  

		// X axis
		if (transform.position.x <= -9f) {
			transform.position = new Vector2(-9f, transform.position.y);
		} else if (transform.position.x >= 9f) {
			transform.position = new Vector2(9f, transform.position.y);
		}

		// Y axis
		if (transform.position.y <= -5f) {
			transform.position = new Vector2(transform.position.x, -5f);
		} else if (transform.position.y >= 5f) {
			transform.position = new Vector2(transform.position.x, 5f);
		}
         
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.freezeRotation = true;
        
        //GameController.instance.BeeDied();
    }
}
