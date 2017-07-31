using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowComic : MonoBehaviour {
  public Sprite[] comic;

  GameManager gm;

  private void Start() {
    gm = GameManager.instance;
  }

  public void Show() {
    StartCoroutine(ComicRoutine());
  }

  IEnumerator ComicRoutine() {
    gm.allScreenButton.gameObject.SetActive(true);
    gm.allScreenButton.interactable = false;
    yield return gm.FadeOut();
    gm.allScreenButton.gameObject.SetActive(true);
    gm.allScreenButton.interactable = true;
    yield return gm.WaitUserInput();
    yield return gm.FadeIn();
    yield return null;
  }
}