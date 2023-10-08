using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour {

  public GameObject LoadingScreen;
  public GameObject creditsScreen;

  private void Start() {
    LoadingScreen.SetActive(false);
  }

  public void StartGame() {
    StartCoroutine(StartGameRoutine());
  }

  IEnumerator StartGameRoutine() {
    LoadingScreen.SetActive(true);
    AsyncOperation async = SceneManager.LoadSceneAsync("Gameplay");
    yield return async;
  }

  public void SetLanguage(string language) {
    PlayerPrefs.SetString("language", language);
  }

  public void OpenURL(string url) {
    Application.OpenURL(url);
  }

  public void ToggleCredits() {
    creditsScreen.SetActive(!creditsScreen.activeSelf);
  }
}