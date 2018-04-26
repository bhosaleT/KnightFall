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

    public AudioSource coinSound;

    public Image healthFull;

    public Sprite heartFull;
    public Sprite oneHit;
    public Sprite twoHit;
    public Sprite threeHit;
    public Sprite noHealth;

    public int maxHealth;
    public int healthCount;

    private bool isRespawning;

    public bool invinsible;

    public Text livesText;
    public int CurrentLives;
    public int startingLives;

    public GameObject gameOverScreen;

    public AudioSource levelMusic;
    public AudioSource gameOverMusic;

    public bool respawnCoActive;
    
    public ResetOnRespawn[] objectsToReset;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
       

        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
        myCoinText.text = "X " + coinCount;

        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            CurrentLives = PlayerPrefs.GetInt("PlayerLives");
        }
        else
        {
            CurrentLives = startingLives;
        }


        healthCount = maxHealth;

        objectsToReset = FindObjectsOfType<ResetOnRespawn>();

        CurrentLives = startingLives;
        livesText.text = "X " + CurrentLives;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (healthCount <= 0 && !isRespawning)
        {
            Respawn();
         
        }
	}
   
    public void Respawn()
    {
        if (!isRespawning)
        {
            CurrentLives -= 1;
            livesText.text = "X " + CurrentLives;

            if (CurrentLives > 0)
            {
                isRespawning = true;
                StartCoroutine("RespawnCo");
            }
            else if (CurrentLives == 0)
            {
                player.gameObject.SetActive(false);
                gameOverScreen.SetActive(true);
                levelMusic.Stop();
                gameOverMusic.Play();
            }

        }
    }

    public IEnumerator RespawnCo()
    {
        respawnCoActive = true;
        player.gameObject.SetActive(false);
        Instantiate(deathSplosion, player.transform.position, player.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);


        respawnCoActive = false;
        healthCount = maxHealth;
        isRespawning = false;
        UpdateHeartMeter();

        coinCount = 0;
        myCoinText.text = "X " + coinCount;

        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);

        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }

    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        //Debug.Log(coinCount);
        myCoinText.text = "X " + coinCount;

        coinSound.Play();
    }

    public void DamagePlayer(int damageToTake)
    {
        if (!invinsible)
        {
            player.hurtSound.Play();
            healthCount -= damageToTake;
            UpdateHeartMeter();
            player.KnockBack();
        }
    }

    public void GiveHealth(int healthToGive)
    {
        healthCount += healthToGive;

        if (healthCount > maxHealth)
        {
            healthCount = maxHealth;
        }

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
