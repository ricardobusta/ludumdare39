using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkMocinhaBartender : MoveToTalkScript {
  bool gotBeer = false;

  protected override IEnumerator TalkRoutine() {
    gm.StartTalking();
    if (!gotBeer) {
      yield return gm.Talk("A beer, please?", gm.Bro);
      yield return gm.Talk("Sure!", gm.MocinhaBartender);
      gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.beerController;
      gm.beerItem.SetActive(true);
      gotBeer = true;
    } else {
      yield return gm.Talk("A beer, please?", gm.Bro);
      yield return gm.Talk("Sorry, that was the last one!", gm.MocinhaBartender);
    }
    gm.StopTalking();
  }
}