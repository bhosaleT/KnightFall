using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is To make a simple fade in effect with the level screens.
public class FadeIn : MonoBehaviour
{

    public float fadeTime;

    private Image blackScreen;
    // Use this for initialization
    void Start()
    {
        blackScreen = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        blackScreen.CrossFadeAlpha(0f, fadeTime, false);

        if (blackScreen.color.a == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
