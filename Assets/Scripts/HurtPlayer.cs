using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    private LevelManager thelevelManager;
    public int damageToGive;
	// Use this for initialization
	void Start () {
        thelevelManager = FindObjectOfType<LevelManager>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            thelevelManager.DamagePlayer(damageToGive);
           // thelevelManager.Respawn();
        }
    }

   
}
