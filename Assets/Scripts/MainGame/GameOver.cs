using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string levelSelect;
    public string mainMenu;
    private LevelManager theLevelManager;

	// Use this for initialization
	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //16|4 Had problem with the GameOver screen, the buttons did not respond to the key presses.
    //19|4 problem solved In the project Hierarchy make sure the Game Over Screen is at the top so its not ovelapped
    //Being overlapped stops the buttons from working.


    public void Restart()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

        SceneManager.LoadScene(levelSelect);
    }

    public void Quit()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
