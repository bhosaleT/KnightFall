using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour {

    public string levelToLoad;
 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnTriggerStay2D(Collider2D other)
    {
      
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}
