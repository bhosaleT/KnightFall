using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController player;

    public GameObject deathSplosion;

    public Text myCoinText;

    public int coinCount;

    public Image healthFull;

    public Sprite heartFull;
    public Sprite oneHit;
    public Sprite twoHit;
    public Sprite threeHit;
    public Sprite noHealth;

    public int maxHealth;
    public int healthCount;

    private bool isRespawning;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        myCoinText.text = "X 0";


        healthCount = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (healthCount <= 0 && !isRespawning)
        {
            Respawn();
            isRespawning = true;
        }
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

        healthCount = maxHealth;
        isRespawning = false;
        UpdateHeartMeter();

        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);
       
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        Debug.Log(coinCount);
        myCoinText.text = "X " + coinCount;
    }

    public void DamagePlayer(int damageToTake)
    {
        healthCount -= damageToTake;
        UpdateHeartMeter();
    }

    public void UpdateHeartMeter()
    {
        switch(healthCount)
        {
            case 4: healthFull.sprite = heartFull;
                break;

            case 3: healthFull.sprite = oneHit;
                break;

            case 2: healthFull.sprite = twoHit;
                break;

            case 1: healthFull.sprite = threeHit;
                break;

            default: healthFull.sprite = noHealth;
                break;

        }
    }
}
