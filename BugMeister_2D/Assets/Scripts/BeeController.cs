using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeController : MonoBehaviour {

    public float speed = 10f;
    public float movement= 0f;
    private Rigidbody2D rb2d;
    private bool isDead = false;
    private bool landed = false;

	public Text winText;
	public Text countText;

	public AudioClip pointsClip; 

    public Transform groundCheckPoint;
    private Animator anim;

	private int count;

	public float startTime;

	public GameObject fruit;
	public GameObject plane;
	public bool youWin = false;
	//private TimeController timeController;

	AudioSource playerAudio;  


 

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		playerAudio = GetComponent <AudioSource> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		//timeController = GetComponent<TimeController>();

	
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
        
        
    }

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("pollen"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			playerAudio.clip = pointsClip;
			playerAudio.Play ();

		}
	}

	void SetCountText ()
	{
		//countText.text = "Count: " + count.ToString ();
		if (count >= 9)
		{
			winText.text = "You Win!";
			youWin = true;
			GetComponent<BeeController>().enabled = false;
			plane.SetActive (false);
			fruit.SetActive(true);

			OnWin ();
//			if (youWin == true && Input.GetKey ("a") || Input.GetKey ("A")) {
//
//				Application.LoadLevel ("Bombus_startPage");
//			}
//
//			if (youWin == true && Mathf.Round (startTime) > 0) {
//
//				GetComponent<TimeController>().enabled = false;
//			}

		}
	}

	public void  OnWin(){
		
		if (youWin == true) {
			StartCoroutine ("Wait");
		}
	}

	IEnumerator Wait()
	{
		print ("wait enabled");
		yield return new WaitForSeconds(3);
		Application.LoadLevel("Bombus_startPage");
	}

}
