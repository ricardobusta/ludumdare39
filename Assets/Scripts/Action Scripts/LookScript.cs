using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour {
  protected GameManager gm;

  private void Start() {
    gm = GameManager.instance;
  }

  public virtual void Action() {
    StartCoroutine(LookRoutine());
  }

  public virtual IEnumerator LookRoutine() {
    gm.StartTalking();
    string talk;
    talk = (gm.language == GameManager.Language.PT_BR) ? "Parece algo maneiro..." : "Looks something nice...";
    yield return gm.Talk(talk, gm.Bro);
    gm.StopTalking();
  }
}