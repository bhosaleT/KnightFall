using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyController : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed;
    private bool canMove;

    private Rigidbody2D myRigidBody;

	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canMove)
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
        }
	}

    void OnBecameInvisible()
    {
        canMove = true;
    }
}
