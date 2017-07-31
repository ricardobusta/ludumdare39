using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMocinho : MoveToTouchScript {
  public ComicManager comic4;

  protected override IEnumerator TouchRoutine() {
    gm.StartTalking();
    if (gm.beerItem.activeSelf) {
      yield return gm.Talk("Here, take this...", gm.Bro);
      yield return gm.FadeOut();
      yield return comic4.ShowComic();
      gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.defaultController;
      gm.beerItem.SetActive(false);
      gm.MocinhoBebado.gameObject.SetActive(true);
      gm.Mocinho.transform.position = new Vector3(1000, 0, 0);
      yield return gm.FadeIn();
      gm.Mocinho.gameObject.SetActive(false);
    } else {
      yield return gm.Talk("He's too nervous for a hug.", gm.Bro);
    }
    gm.StopTalking();
  }
}