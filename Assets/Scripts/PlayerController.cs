using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D playerBody; //rigidbody variable.

    public float jumpSpeed;// jump distance variable.

    public Transform groundCheck; //transform is any object in world which has a position.
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator myAnim;

    public Vector3 respawnPosition;
    public LevelManager theLevelManager;

	// Use this for initialization
	void Start () {

        //Getting the rigidbody from the player GameObject.
        playerBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        theLevelManager = FindObjectOfType<LevelManager>();
        respawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);// this draws a virtual circle and then checks all the attributes

        if (Input.GetAxisRaw("Horizontal") > 0f) // if input on horizontal axis is greater that zero (RIGHT).
        {
            playerBody.velocity = new Vector3(moveSpeed, playerBody.velocity.y, 0f); // keep the y speed same as it is, and make the z 0 because no need to use z in 2D game.
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f) // if input on horizontal axis is less that zero. (LEFT)
        {
            playerBody.velocity = new Vector3(-moveSpeed, playerBody.velocity.y, 0f); // keep the y speed same as it is, and make the z 0 because no need to use z in 2D game.
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            playerBody.velocity = new Vector3(0f, playerBody.velocity.y, 0f);//stop when no input.
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            playerBody.velocity = new Vector3(playerBody.velocity.x, jumpSpeed, 0f); //the x axis should stay the same to add direction to the jump.
        }

        myAnim.SetFloat("Speed", Mathf.Abs(playerBody.velocity.x)); //math function.abs gives the absolute value.[unsigned]
        myAnim.SetBool("Ground", isGrounded);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            // gameObject.SetActive(false); // disable the game object that is player.
            //transform.position = respawnPosition;
            theLevelManager.Respawn();
        }

        if (other.tag == "CheckPoint")
        {
            respawnPosition = other.transform.position; // save the location of the checkpoints.
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
        
    }
}
