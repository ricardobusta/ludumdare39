using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkNina : MoveToTalkScript {
  bool talked = false;

  public ComicManager comic6;

  protected override IEnumerator TalkRoutine() {
    gm.StartTalking();
    if (!talked) {
      yield return gm.Talk("Hey, can you give me a hand with him, please?", gm.Bro);
      yield return gm.Talk("...", gm.Nina);
      yield return gm.FadeOut();
      yield return comic6.ShowComic();
      gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.defaultController;
      gm.bucketItem.SetActive(false);

      gm.Nina.gameObject.SetActive(true);
      gm.MocinhoMolhado.gameObject.SetActive(true);
      gm.MocinhoBebado.transform.position = new Vector3(1000, 0, 0);
      yield return gm.FadeIn();
    } else {
      yield return gm.Talk("Thanks!", gm.Bro);
      yield return gm.Talk("...", gm.Nina);
    }
    gm.StopTalking();
  }
}