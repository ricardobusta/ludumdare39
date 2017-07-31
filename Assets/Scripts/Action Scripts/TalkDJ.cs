using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkDJ : MoveToTalkScript {
  protected override IEnumerator TalkRoutine() {
    gm.StartTalking();
    yield return gm.Talk("Talk t talk 1", gm.Bro);
    yield return gm.Talk("Talk t talk 2", gm.Bro);
    yield return gm.Talk("Talk t talk 3", gm.Bro);
    gm.StopTalking();
  }
}