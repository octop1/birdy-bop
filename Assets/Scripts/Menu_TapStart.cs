﻿using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

public class Menu_TapStart : MonoBehaviour {

    private TapGesture tapGesture;
    public GameObject circle_transition;

    private void OnEnable()
    {
        tapGesture = GetComponent<TapGesture>();

        tapGesture.Tapped += tappedHandler;

        Debug.Log("Subscribed to tap");


    }

    private void OnDisable()
    {
       tapGesture.Tapped -= tappedHandler;
    }

    private void tappedHandler(object sender, EventArgs e)
    {
        Debug.Log("Tap registered");
        FadeOut();
    }

    private void FadeOut()
    {
        circle_transition.GetComponent<Animator>().Play("BeginRoll");
        StartCoroutine(WaitForRoll());
    }

    IEnumerator WaitForRoll()
    {
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel(2);
    }
}
