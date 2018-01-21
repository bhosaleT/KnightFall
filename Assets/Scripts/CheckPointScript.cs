using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    public Sprite flagClosed;
    public Sprite flagOpen;


    private SpriteRenderer theSpriteRenderer;
	// Use this for initialization
	void Start () {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theSpriteRenderer.sprite = flagOpen; //changing the sprite. 
        }
        else {
            theSpriteRenderer.sprite = flagClosed;
        }
    }
}
