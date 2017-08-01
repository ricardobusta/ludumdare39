using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkMimiTedio : MoveToTalkScript {
  protected override IEnumerator TalkRoutine() {
    gm.StartTalking();
    yield return gm.Talk("The music is so boring...", gm.MimiEntediada);
    gm.StopTalking();
  }
}