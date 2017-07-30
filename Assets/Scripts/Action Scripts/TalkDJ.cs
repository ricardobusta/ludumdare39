using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkDJ : MoveToTalkScript {
  protected override IEnumerator TalkRoutine() {
    gm.speechBubble.Show("Lero Lero", interaction);
    yield return null;
  }
}