using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAttacking : MonoBehaviour {

    public Animator myAnim;
    public bool startAxing;

    public GameObject attackBox;
    public float seconds;

    // Use this for initialization
    void Start () {
        myAnim = transform.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine("AttackOn");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopCoroutine("AttackOn");
        }
    }


    public IEnumerator AttackOn()
    {
        startAxing = true;
        attackBox.SetActive(true);
        myAnim.SetBool("attackPlayer", startAxing);
        yield return new WaitForSeconds(seconds);

    }

    
}
