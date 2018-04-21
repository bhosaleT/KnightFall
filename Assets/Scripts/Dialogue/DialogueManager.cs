using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

   private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;

    public Animator theAnimator;
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue)
    {
        theAnimator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
       // Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            yield return null;
        }
    }

    void EndDialogue()
    {
      
        theAnimator.SetBool("isOpen", false);
    }
}
