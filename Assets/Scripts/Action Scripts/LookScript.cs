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
    yield return gm.Talk("Lorem Ipsum", gm.Bro);
    gm.StopTalking();
  }
}