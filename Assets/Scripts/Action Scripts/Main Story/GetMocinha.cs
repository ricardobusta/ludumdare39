using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMocinha : MoveToTouchScript {

  public override IEnumerator TouchRoutine() {
    gm.StartTalking();
    yield return gm.Talk("Come with me", gm.Bro);
    gm.StopTalking();
  }
}