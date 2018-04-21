using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButtonDown("Interact"))
            {
                TriggerDialogue();
            }
        }
    }


    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

}

