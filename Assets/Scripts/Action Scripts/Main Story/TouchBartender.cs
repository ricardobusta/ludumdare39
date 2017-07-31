using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBartender : MoveToTouchScript {

  public override void Action() {
    if (gm.mocinhaItem.activeSelf) {
      gm.player.MoveTo(interactionPos, gameObject, direction);
    } else {
      StartCoroutine(TouchRoutine());
    }
  }

  protected override IEnumerator TouchRoutine() {
    gm.StartTalking();
    if (gm.mocinhaItem.activeSelf) {
      yield return gm.Talk("Excuse-me, sir...", gm.Bro);
      gm.Bartender.gameObject.SetActive(false);
      gm.MocinhaBartender.gameObject.SetActive(true);
      gm.mocinhaItem.SetActive(false);
      gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.defaultController;
    } else {
      yield return gm.Talk("He seems too busy for a fist wrestling.", gm.Bro);
    }
    gm.StopTalking();
  }
}