using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenCollider : MonoBehaviour {

	private SpriteRenderer pollen;
	//private float duration = 3f;
	private Color32 colorBlue;
	//public bool pesticide = false;
	//private TimeController time;
	//private int timeToPesticide;
	//private int randomTime;


	void Start ()
	{
		colorBlue = new Color32(255, 100,150, 200);
		pollen = GetComponent<SpriteRenderer>();
		//pollen.color = colorBlue;
		//time = FindObjectOfType<TimeController>();

	}


	void OnTriggerExit2D(Collider2D other) {
		
		//if (coll.gameObject.tag == "Player")
			pollen.color = colorBlue;
			//pollen.color = Color.Lerp(pollen.color, colorBlue, Time.time * 0.5f);	

	}

//	public void ChangeColor ()
//	{
//
//		if (timeToPesticide % 8 == 0)
//		{
//			pesticide = true;
//			pollen.color = Color.Lerp(colorBlue, Color.black, Time.time * 0.5f);
//		}
//
//
//		if ( timeToPesticide % 9 == 0)
//		{
//			pesticide = false;
//			pollen.color = Color.Lerp(pollen.color, colorBlue, Time.time * 0.5f);
//		}
//
//	}
}