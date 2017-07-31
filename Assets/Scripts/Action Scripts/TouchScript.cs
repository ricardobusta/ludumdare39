using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour {
  protected GameManager gm;

  private void Start() {
    gm = GameManager.instance;
  }

  public virtual void Action() {
    StartCoroutine(TouchRoutine());
  }

  public virtual IEnumerator TouchRoutine() {
    gm.StartTalking();
    string talk;
    talk = (gm.language == GameManager.Language.PT_BR) ? "Não quero tocar nisso..." : "I don't want to touch that...";
    yield return gm.Talk(talk, gm.Bro);
    gm.StopTalking();
  }
}