using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public string levelSelect;
    public string mainMenu;
    private LevelManager theLevelManager;
    public GameObject thePauseScreen;
    private PlayerController thePlayer;

    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Made a new input method in Unity for escape button and the Start button in Xbox controller to pause the game.
        if (Input.GetButtonDown("Pause"))
        {
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        thePlayer.canMove = false;
        Time.timeScale = 0f;
        theLevelManager.levelMusic.Pause();
        thePauseScreen.SetActive(true);
    }

    public void ResumeGame()

    {
        thePlayer.canMove = true;
        Time.timeScale = 1f;
        theLevelManager.levelMusic.Play();
        thePauseScreen.SetActive(false);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);
        PlayerPrefs.SetInt("CoinCount", 0);



        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
