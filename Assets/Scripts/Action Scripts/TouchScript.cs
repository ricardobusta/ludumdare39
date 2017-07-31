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
    yield return gm.Talk("Lorem Ipsum", gm.Bro);
    gm.StopTalking();
  }
}