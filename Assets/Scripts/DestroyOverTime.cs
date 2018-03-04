using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    public float lifeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /* ######################CONCEPT##################*/
        /*This script when attatched to an object gives it a lifetime 
         *Time.deltaTime keeps track of seconds passing in the game
         * and lifeTime - Time.deltaTime keeps tracking it until it becomes 0
         * then the gameObject is Destroyed.
         * USED on the particle Effect object to stop it from cluttering the Game Memory.
         */
         
        lifeTime = lifeTime - Time.deltaTime;
         
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
