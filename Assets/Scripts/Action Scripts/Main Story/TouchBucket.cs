using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBucket : MoveToTouchScript {
  public override void Action() {
    if (gm.MocinhoBebado.gameObject.activeSelf) {
      gm.player.MoveTo(interactionPos, gameObject, direction);
    } else {
      StartCoroutine(TouchRoutine());
    }
  }

  protected override IEnumerator TouchRoutine() {
    gm.StartTalking();
    if (gm.MocinhoBebado.gameObject.activeSelf) {
      yield return gm.Talk("Maybe this can help!", gm.Bro);
      gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.bucketController;
      gm.bucketItem.SetActive(true);
      gm.Bucket.gameObject.SetActive(false);
    } else {
      yield return gm.Talk("There's no one too drunk to need this.", gm.Bro);
    }
    gm.StopTalking();
  }
}