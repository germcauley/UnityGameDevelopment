﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFaderScript : MonoBehaviour {

    public static SceneFaderScript instance;

    [SerializeField]
    private GameObject fadeCanvas;

    [SerializeField]
    private Animator fadeAnim;

    void Awake()
    {
        MakeSingleton();
    }
	
	void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FadeIn(string levelName)
    {
        StartCoroutine(FadeInAnimatation(levelName));

    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutAnimation());
    }


    IEnumerator FadeInAnimatation(string levelName)
    {
        fadeCanvas.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f));
       
        Application.LoadLevel(levelName);
        FadeOut();
    }

    IEnumerator FadeOutAnimation()
    {
        fadeAnim.Play("FadeOut");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f));
        fadeCanvas.SetActive(false);
    }
}
