using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{

    //types of level names to load.
    public string levelToLoad;
    public LevelManager theLevelManager;
    private PlayerController thePlayer;

    public float waitToMove;
    public float waitToLoad;
    public Sprite flagOpen;
    private bool movePlayer;
    public SpriteRenderer theSpriteRenderer;
    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
        
        theSpriteRenderer = FindObjectOfType<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movePlayer == true)
        {
            thePlayer.playerBody.velocity = new Vector3(thePlayer.moveSpeed, thePlayer.playerBody.velocity.y, 0f);
        }
    }

    //This trigger is used to load the new Level.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            theSpriteRenderer.sprite = flagOpen;
            StartCoroutine("LevelEndCo");
            // SceneManager.LoadScene (levelToLoad);
            // theTextBox.isActive = false;
        }
    }

    public IEnumerator LevelEndCo()
    {
        thePlayer.canMove = false;

        theLevelManager.invinsible = true;
        thePlayer.playerBody.velocity = Vector3.zero;

        theLevelManager.levelMusic.Stop();
        theLevelManager.gameOverMusic.Play();

        PlayerPrefs.SetInt("CoinCount", theLevelManager.coinCount);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.CurrentLives);

        yield return new WaitForSeconds(waitToMove);

        movePlayer = true;

        yield return new WaitForSeconds(waitToLoad);

        SceneManager.LoadScene(levelToLoad);
    }

}