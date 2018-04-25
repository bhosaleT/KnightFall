using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour {

    public bool bossActive;

    public float timeBetweenDrops;
    private float timeBetweenDropsStore;
    private float dropCount;


    public float waitForPlatforms;
    private float platformCount;

    public Transform leftPoint;
    public Transform RightPoint;
    public Transform dropFireSpawnPoint;

    public GameObject dropFire;

    public GameObject theBoss;
    public bool bossRight;

    public GameObject rightPlatform;
    public GameObject leftPlatform;

    public bool takeDamage;

    public int startingHealth;
    public int currentHealth;

    public GameObject theCheckPoint;
    public GameObject theLevelEnd;

    public Text enemyHealthText;

    private LevelManager theLevelManager;

    public bool waitingForRespawn;

    public GameObject healthPotion;

    public Transform healthPotionPosition;

	// Use this for initialization
	void Start ()
    {
        timeBetweenDropsStore = timeBetweenDrops;
        dropCount = timeBetweenDrops;
        platformCount = waitForPlatforms;
        currentHealth = startingHealth;

        theBoss.transform.position = RightPoint.position;
        bossRight = true;
        enemyHealthText.text =  currentHealth + " X";
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (theLevelManager.respawnCoActive)
        {
            bossActive = false;
            waitingForRespawn = true;
        }

        //To reset the whole level when the player respawns.
        if (waitingForRespawn && !theLevelManager.respawnCoActive)
        {

            theBoss.SetActive(false);
            leftPlatform.SetActive(false);
            rightPlatform.SetActive(false);

            platformCount = waitForPlatforms;
            dropCount = timeBetweenDrops;

            theBoss.transform.position = RightPoint.position;
            bossRight = true;
            currentHealth = startingHealth;
            enemyHealthText.text = startingHealth + " X";
            timeBetweenDrops = timeBetweenDropsStore;
            waitingForRespawn = false;
        }

        if (bossActive)
        {
            theBoss.SetActive(true);
            if (dropCount > 0)
            {
                dropCount -= Time.deltaTime;
            }
            else
            { 
                //move the position of the fireball spawner from left to right.
                dropFireSpawnPoint.position = new Vector3(Random.Range(leftPoint.position.x, RightPoint.position.x), dropFireSpawnPoint.position.y, dropFireSpawnPoint.position.z);

                //Then instantiate it in one randomly chosen location.
                Instantiate(dropFire, dropFireSpawnPoint.position, dropFireSpawnPoint.rotation);
                dropCount = timeBetweenDrops;
            }

            //Shifting between platforms for the left and right boss.
            if (bossRight == true)
            {
                if (platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    rightPlatform.SetActive(true);
                }
            }
            else
            {
                if (platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    leftPlatform.SetActive(true);
                }
            }

            if (takeDamage == true)
            {
                currentHealth -= 1;

                enemyHealthText.text = currentHealth + " X"; //Implemented a simple numberical UI for enemy health.
                //TODO Change it to health bar.

                if (currentHealth <= 0)
                {
                    theCheckPoint.SetActive(true);
                    theLevelEnd.SetActive(true);
                    gameObject.SetActive(false);
                }

                //Changing the position of the boss from one point to another.
                if (bossRight == true)
                {
                    theBoss.transform.position = leftPoint.position;
                    //the original position is left facing.
                    //so making the x axis of the localscale -1 to make it face right.
                    theBoss.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    theBoss.transform.position = RightPoint.position;
                    //opposite of what is done above.
                    theBoss.transform.localScale = new Vector3(1f, 1f, 1f);
                }

                bossRight = !bossRight;

                rightPlatform.SetActive(false);
                leftPlatform.SetActive(false);

                platformCount = waitForPlatforms;

                timeBetweenDrops = timeBetweenDrops / 2f;

                takeDamage = false;
            }
        }
        
	}

    //simple trigger to detect when the player is in the boss area.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bossActive = true;
           
        }
    }
}

