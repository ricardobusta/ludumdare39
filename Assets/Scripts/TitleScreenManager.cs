using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour {

  public GameObject LoadingScreen;

  private void Start() {
    LoadingScreen.SetActive(false);
  }

  public void StartGame() {
    StartCoroutine(StartGameRoutine());
  }

  IEnumerator StartGameRoutine() {
    LoadingScreen.SetActive(true);
    AsyncOperation async = SceneManager.LoadSceneAsync("Game");
    yield return async;
  }
}