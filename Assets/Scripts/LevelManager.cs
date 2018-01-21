using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController player;

    public GameObject deathSplosion;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        player.gameObject.SetActive(false);
        Instantiate(deathSplosion, player.transform.position, player.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);
        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);
       
    }
}
