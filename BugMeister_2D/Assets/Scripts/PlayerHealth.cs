using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{	
	public float health = 100f;					// The amount of health the player starts the game with.
	public float currentHealth; 					 // The current health the player has.
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.

	public Slider healthSlider;					 // Reference to the UI's health bar.
	public Image damageImage;					 // Reference to an image to flash on the screen on being hurt.
	public AudioClip deathClip;                     // The audio clip to play when the player dies.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

	public float damageAmount = 10f;			// The amount of damage to take when enemies touch the player

	//private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	//private Vector3 healthScale;				// The local scale of the health bar initially (with full health).
	private BeeController beeController;		// Reference to the PlayerControl script.
	private Animator anim;						// Reference to the Animator on the player
    //private WaterController water;

	AudioSource playerAudio;                                    // Reference to the AudioSource component.

	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.


	void Awake ()
	{
		// Setting up references.
		beeController = GetComponent<BeeController>();
		//healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
        //water = GetComponent<WaterController>();
		playerAudio = GetComponent <AudioSource> ();

		// Getting the intial scale of the healthbar (whilst the player has full health).
		//healthScale = healthBar.transform.localScale;
		currentHealth = health;
	}

	void Update ()
	{
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		// Reset the damaged flag.
		damaged = false;
	}


	//Lina's code for taking damage
	void OnCollisionEnter2D (Collision2D col)
	{
		// If the colliding gameobject is an Enemy...
		if(col.gameObject.tag == "airplane")
		{
			// ... and if the time exceeds the time of the last hit plus the time between hits...
			if (Time.time > lastHitTime + repeatDamagePeriod) 
			{
				// ... and if the player still has health...
				if(health > 0f)
				{
					// ... take damage and reset the lastHitTime.
					TakeDamage(col.transform); 
					lastHitTime = Time.time; 
				}
				// If the player doesn't have health, do some stuff, let him fall into the river to reload the level.
				else
				{

					// ... disable user Player Control script
					GetComponent<BeeController>().enabled = false;
					//GameController.instance.BeeDied();
					anim.SetTrigger("Died");
				}
			}
		}
	}

	//also Lina's code for taking damage
	void TakeDamage (Transform enemy)
	{
		damaged = true;
		// Reduce the player's health by 10.
		health -= damageAmount;

		// Update what the health bar looks like.
		//UpdateHealthBar();

	}
//	public void TakeDamage (int amount)
//	{
//		// Set the damaged flag so the screen will flash.
//		damaged = true;
//
//		// Reduce the current health by the damage amount.
//		currentHealth -= amount;
//
//		// Set the health bar's value to the current health.
//		healthSlider.value = currentHealth;
//
//		// Play the hurt sound effect.
//		playerAudio.Play ();
//
//		// If the player has lost all it's health and the death flag hasn't been set yet...
//		if(currentHealth <= 0 && !isDead)
//		{
//			// ... it should die.
//			Death ();
//		}
//	}

	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;

		// Turn off any remaining shooting effects.
		//playerShooting.DisableEffects ();

		// Tell the animator that the player is dead.
		anim.SetTrigger ("died");

		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
		playerAudio.clip = deathClip;
		playerAudio.Play ();

		// Turn off the movement and shooting scripts.
		//BeeController.enabled = false;
		//playerShooting.enabled = false;
	}

	//also LIna code for health bar.
//	public void UpdateHealthBar ()
//	{
//		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
//		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
//
//		// Set the scale of the health bar to be proportional to the player's health.
//		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
//	}
}

