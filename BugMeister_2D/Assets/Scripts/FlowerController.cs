using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {
    private WaterController waterColor;
    private SpriteRenderer flowerColor;
    private bool pesticide;
    private Color32 flowerColorActual;
    private Color32 flowerGray;
	// Use this for initialization
	void Start () {

        waterColor = FindObjectOfType < WaterController>();
        flowerColor = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        flowerColorActual = new Color32(255,255,255,255);
        flowerGray = new Color32(80,70,70,255);
        pesticide = waterColor.pesticide;

        if (pesticide == true)
        {
            flowerColor.color = Color.Lerp(flowerColorActual,flowerGray, Time.time * 0.5f );
        }
        if(pesticide == false)

        {
            flowerColor.color = flowerColorActual;
        }
		

	}
}
