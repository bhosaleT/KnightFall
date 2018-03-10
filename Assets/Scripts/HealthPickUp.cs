using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    public int healthToGive;

    public GameObject healthSplosion;
    private LevelManager theLevelManager;

	// Use this for initialization
	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.GiveHealth(healthToGive);
            gameObject.SetActive(false);
            Instantiate(healthSplosion, transform.position, Quaternion.identity);
        }
    }
}
