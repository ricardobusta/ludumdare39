using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkScript : MonoBehaviour {
  protected GameManager gm;

  private void Start() {
    gm = GameManager.instance;
  }

  public virtual void Action() {
    StartCoroutine(TalkRoutine());
  }

  protected virtual IEnumerator TalkRoutine() {
    gm.StartTalking();
    string talk;
    talk = (gm.language == GameManager.Language.PT_BR) ? "Não sei o que falar..." : "I don't know what to talk...";
    yield return gm.Talk(talk, gm.Bro);
    gm.StopTalking();
  }
}