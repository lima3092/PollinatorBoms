using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackgroundBee : MonoBehaviour {
    private BoxCollider2D skycollider;
    private float skydHorizontalLength;
    // Use this for initialization
    void Start ()
    {
        skycollider = GetComponent<BoxCollider2D>();
        skydHorizontalLength = skycollider.size.x;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < -skydHorizontalLength)
        {
            RepositionBackground();
        }
    }
    private void RepositionBackground()
    {
        Vector2 skyOffset = new Vector2(skydHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + skyOffset;
    }
}
