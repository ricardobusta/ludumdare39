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
    yield return gm.Talk("Talk talk 1", gm.Bro);
    yield return gm.Talk("Talk talk 2", gm.Bro);
    yield return gm.Talk("Talk talk 3", gm.Bro);
    gm.StopTalking();
  }
}