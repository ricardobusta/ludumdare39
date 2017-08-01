using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
  public void OpenURL(string url) {
    Application.OpenURL(url);
  }

  public void BackToTitle() {
    SceneManager.LoadScene("Title Screen");
  }
}