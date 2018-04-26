using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Rigidbody2D playerBody; //rigidbody variable.

    public float jumpSpeed;// jump distance variable.

    public Transform groundCheck; //transform is any object in world which has a position.
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator myAnim;

    public Vector3 respawnPosition;
    public LevelManager theLevelManager;

    public GameObject stompBox;

    public float knockBackForce;
    public float knockBackLength;
    private float knockBackCounter;


    public float invincibilityLength;
    private float invincibilityCounter;

    public AudioSource hurtSound;
    public TextBoxManager dialogueBox;
    
    public bool canMove;
     
   
    public bool isAttacking;
    public GameObject attackBox;

	// Use this for initialization
	void Start () {
        //Getting the rigidbody from the player GameObject.
        playerBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        theLevelManager = FindObjectOfType<LevelManager>();
        respawnPosition = transform.position;
        dialogueBox = FindObjectOfType<TextBoxManager>();
       
    }
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);// this draws a virtual circle and then checks all the attributes
        if (canMove )
        {
            if (knockBackCounter <= 0)
            {
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

                if (Input.GetButtonDown("Fire1"))
                {
                    isAttacking = true;
                    attackBox.SetActive(true);
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    isAttacking = false;
                    attackBox.SetActive(false);
                }

                if (invincibilityCounter > 0)
                {
                    invincibilityCounter -= Time.deltaTime;
                }

                if (invincibilityCounter <= 0)
                {
                    theLevelManager.invinsible = false;
                }

            }
        }
        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;
            //check which direction the player is facing and then knock him back in the opposite direction.
            if (transform.localScale.x > 0)
            {
               
                playerBody.velocity = new Vector3(-knockBackForce, knockBackForce, 0f);
            }
            else
            {
              
                playerBody.velocity = new Vector3(knockBackForce, knockBackForce, 0f);
            }
        }

        myAnim.SetFloat("Speed", Mathf.Abs(playerBody.velocity.x)); //math function.abs gives the absolute value.[unsigned]
        myAnim.SetBool("Ground", isGrounded);
        myAnim.SetBool("Attack", isAttacking);

        if (playerBody.velocity.y < 0)
        {
            stompBox.SetActive(true); //the stompbox should only be active when the player falls down.
        }
        else
        {
            stompBox.SetActive(false);
        }
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        invincibilityCounter = invincibilityLength;
        theLevelManager.invinsible = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            // gameObject.SetActive(false); // disable the game object that is player.
            //transform.position = respawnPosition;
            theLevelManager.Respawn();
            //theLevelManager.healthCount = 0;
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
