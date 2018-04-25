using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour {

    public GameObject target;
    public float followAhead;// to show the player some forward environment we use followahead to keep the camera ahead of player.
    public float followUp;

    private Vector3 targetPosition;
    public float smoothing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform works on the GameObject that the script is attatched to .
        //so because our game has some verticality we add the targets x and y position to the movement of the camera.
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        if (target.transform.localScale.x > 0f)//we are facing right.
        {
            targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
        }
        else
        {
            targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
        }

        //transform.position = targetPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime); 
        //what lerp does is it takes current position and target position and adds a transition to it.
	}
}
