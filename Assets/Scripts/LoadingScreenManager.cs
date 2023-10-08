﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour {
  public Image[] logos;
  public float time;

  AsyncOperation async;

  void Start() {
    //foreach (Image logo in logos) {
    //logo.gameObject.SetActive(false);
    //}
    StartCoroutine(LoadScene());
  }

  IEnumerator LoadScene() {
    async = SceneManager.LoadSceneAsync("TitleScreen");
    async.allowSceneActivation = false;
    StartCoroutine(LogoScene());
    yield return async;
  }

  IEnumerator LogoScene() {
    const float totalTime = 2;
    Color c = Color.white;
    time = 0;
    while (time < totalTime) {
      time += Time.deltaTime;
      c.a = time / totalTime;
      foreach (Image logo in logos) {
        logo.color = c;
      }
      yield return new WaitForEndOfFrame();
    }
    time = 0;
    while (time < totalTime) {
      time += Time.deltaTime;
      c.a = 1 - (time / totalTime);
      foreach (Image logo in logos) {
        logo.color = c;
      }
      yield return new WaitForEndOfFrame();
    }

    async.allowSceneActivation = true;
  }

  private void Update() {
    if (Input.GetMouseButtonDown(0)) {
      async.allowSceneActivation = true;
    }
  }
}