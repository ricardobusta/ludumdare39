using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMocinho : MoveToTouchScript {
  protected override IEnumerator TouchRoutine() {
    gm.StartTalking();
    if (gm.beerItem.activeSelf) {
      yield return gm.Talk("Here, take this...", gm.Bro);
      gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.defaultController;
      gm.beerItem.SetActive(false);
      gm.Mocinho.gameObject.SetActive(false);
      gm.MocinhoBebado.gameObject.SetActive(true);
    } else {
      yield return gm.Talk("He's too nervous for a hug.", gm.Bro);
    }
    gm.StopTalking();
  }
}