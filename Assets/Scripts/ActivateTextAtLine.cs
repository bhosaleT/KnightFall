using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;
    public int startPoint;
    public int endLine;

    public bool destroyWhenActivated;
    public TextBoxManager theTextBox;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startPoint;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
        }
    }
}
