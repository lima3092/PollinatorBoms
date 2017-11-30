using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeController : MonoBehaviour {
    public float startTime;
    private Text timeText;
	//private BeeController beeController;

	// Use this for initialization

	void Awake () {
		//beeController = GetComponent<BeeController>();
	}
	void Start ()
    {
        timeText = GetComponent<Text>();
		// Setting up references.

	}
	
	// Update is called once per frame
	void Update ()
    {
        startTime -= Time.deltaTime;
        timeText.text = "Time 00:" + Mathf.Round(startTime);

        if (Mathf.Round(startTime) == 0)
        {
            startTime = 0f;
            timeText.text = "Time 00:" + startTime;
            GameController.instance.BeeDied();
			//TimeOut ();
			//GetComponent<BeeController>().enabled = false;
            
        }

    }


}
