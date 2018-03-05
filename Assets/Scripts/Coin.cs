using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject coinSplosion;
    private LevelManager thelevelManager;
    public int coinValue;

	// Use this for initialization
	void Start () {
        thelevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            thelevelManager.AddCoins(coinValue);
            Destroy(gameObject);
            Instantiate(coinSplosion, transform.position, Quaternion.identity);
            
        }
    }
}
