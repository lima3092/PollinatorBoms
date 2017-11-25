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
		if (gameOver == true && Input.GetKey("up"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


	}

    public void BeeDied ()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
