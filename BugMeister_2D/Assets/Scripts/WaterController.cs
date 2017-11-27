using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {
    private SpriteRenderer water;
    private float duration = 3f;
    private Color32 colorBlue;
    public bool pesticide = false;
    private TimeController time;
    private int timeToPesticide;
    private int randomTime;
	// Use this for initialization
	void Start ()
    {
        colorBlue = new Color32(3, 150, 171, 255);
        water = GetComponent<SpriteRenderer>();
        water.color = colorBlue;
        time = FindObjectOfType<TimeController>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeToPesticide = (int) Mathf.Round(time.startTime) ;
        ChangeColor();      

    }
    public void ChangeColor ()
    {

        if (timeToPesticide % 8 == 0)
        {
            pesticide = true;
            water.color = Color.Lerp(colorBlue, Color.black, Time.time * 0.5f);
        }


        if ( timeToPesticide % 9 == 0)
        {
            pesticide = false;
            water.color = Color.Lerp(water.color, colorBlue, Time.time * 0.5f);
        }

    }
}
