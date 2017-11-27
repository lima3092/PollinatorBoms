using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public float scrollSpeed = -1.5f;
    public bool gameOver = false;
    public GameObject gameOverText;



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


		if (gameOver == true && Input.GetKey("up"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


	}

    public void BeeDied ()
    {
        gameOverText.SetActive(true);
        gameOver = true;
		//Application.LoadLevel("Bombus_startPage");
    }
}


