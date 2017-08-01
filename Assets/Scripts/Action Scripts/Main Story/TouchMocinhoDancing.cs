using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMocinhoDancing : MoveToTouchScript {
  protected override IEnumerator TouchRoutine() {
    gm.StartTalking();
    yield return gm.GameOverRoutine();
  }
}