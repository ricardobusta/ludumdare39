using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMocinhoBebado : MoveToTouchScript {
  protected override IEnumerator TouchRoutine() {
    gm.StartTalking();
    yield return gm.Talk("He's too nervous for a hug.", gm.Bro);
    gm.StopTalking();
  }
}