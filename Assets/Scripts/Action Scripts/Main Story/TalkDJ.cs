using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkDJ : MoveToTalkScript {
  protected override IEnumerator TalkRoutine() {
    gm.StartTalking();
    if (gm.MimiEntediada.gameObject.activeSelf) {
      yield return gm.Talk("Dude, can you get a better music playing?", gm.Bro);
      yield return gm.Talk("Sure, bro!", gm.DJ);
      yield return gm.FadeOut();
      gm.MimiEntediada.gameObject.SetActive(false);
      gm.MimiFeliz.gameObject.SetActive(true);
      AudioSource asor = FindObjectOfType<AudioSource>();
      if (asor != null) {
        asor.pitch = 1.6f;
      }
      yield return gm.FadeIn();
    } else {
      yield return gm.Talk("Hey!", gm.Bro);
      yield return gm.Talk("Sup!", gm.DJ);
    }
    gm.StopTalking();
  }
}