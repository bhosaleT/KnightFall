using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public string firstLevel;
    public string LevelSelect;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(LevelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
