using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public float scrollSpeed = -1.5f;
    public bool gameOver = false;
    public GameObject gameOverText;
	public GameObject buzzAudio;


	public bool isDead;

	private PlayerHealth playerHealth;
	//private BeeController beeController;
	//private BackgroundPropSpawner backgroundPropSpawner;





    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

		playerHealth = GetComponent<PlayerHealth>();
		//backgroundPropSpawner = GetComponent <BackgroundPropSpawner>() ;
		//GetComponent<BeeController>().enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

		// X axis
		if (transform.position.x <= -4.3f) {
			transform.position = new Vector2(-4.3f, transform.position.y);
		} else if (transform.position.x >= 4.3f) {
			transform.position = new Vector2(4.3f, transform.position.y);
		}

		// Y axis
		if (transform.position.y <= -2.7f) {
			transform.position = new Vector2(transform.position.x, -2.7f);
		} else if (transform.position.y >= 2.7f) {
			transform.position = new Vector2(transform.position.x, 2.7f);
		}

		//blanking this out to test if the GameOverManager script can do this instead
//		if (gameOver == true) /*&& Input.GetKey("up")*/       {
		if (gameOver == true && Input.GetKey ("s") || Input.GetKey ("S")) {

			Application.LoadLevel ("Bombus_startPage");
			gameOver = false;
		}
//			Buzz.Stop() //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }




    public void BeeDied ()
    { 
		//if (isDead = true) {
	
			gameOverText.SetActive (true);
			gameOver = true;
			buzzAudio.SetActive (false);

		//GetComponent<BeeController>().enabled = false;

	


		}
		//}
    
}


