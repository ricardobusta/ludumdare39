using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicManager : MonoBehaviour {
  public GameObject[] comic;

  GameManager gm;

  private void Start() {
    foreach (GameObject go in comic) {
      go.SetActive(false);
    }
    gameObject.SetActive(false);
    Debug.Log(name);
  }

  public IEnumerator ShowComic() {
    Debug.Log("Show Comic" + name);

    gm = GameManager.instance;

    gameObject.SetActive(true);
    Debug.Log("Showing");
    const float comicShowTime = 0.5f;
    for (int i = 0; i < comic.Length; i++) {
      Debug.Log("Asd" + i);
      gm.allScreenButton.interactable = false;
      comic[i].SetActive(true);
      float time = 0;
      while (time < comicShowTime) {
        time += Time.deltaTime;
        yield return new WaitForEndOfFrame();
      }
      gm.allScreenButton.interactable = true;
      yield return gm.WaitUserInput();
    }
    foreach (GameObject go in comic) {
      go.SetActive(false);
    }
    gameObject.SetActive(false);
  }
}