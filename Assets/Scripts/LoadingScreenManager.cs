using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour {
  public Image[] logos;
  public float time;

  AsyncOperation async;

  void Start() {
    foreach (Image logo in logos) {
      logo.gameObject.SetActive(false);
    }
    StartCoroutine(LoadScene());
  }

  IEnumerator LoadScene() {
    async = SceneManager.LoadSceneAsync("Title Screen");
    async.allowSceneActivation = false;
    StartCoroutine(LogoScene());
    yield return async;
  }

  IEnumerator LogoScene() {
    const float totalTime = 3;

    foreach (Image logo in logos) {
      time = 0;
      logo.gameObject.SetActive(true);
      Color c = logo.color;
      while (time < totalTime) {
        time += Time.deltaTime;
        c.a = time / totalTime;
        logo.color = c;
        yield return new WaitForEndOfFrame();
      }
      time = 0;
      while (time < totalTime) {
        time += Time.deltaTime;
        c.a = 1 - (time / totalTime);
        logo.color = c;
        yield return new WaitForEndOfFrame();
      }
    }
    async.allowSceneActivation = true;
  }

  private void Update() {
    if (Input.GetMouseButtonDown(0)) {
      async.allowSceneActivation = true;
    }
  }
}