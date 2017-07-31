using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBartender : MoveToTouchScript {

  public ComicManager comic2;
  public ComicManager comic3;

  public override void Action() {
    if (gm.mocinhaItem.activeSelf) {
      gm.player.MoveTo(interactionPos, gameObject, direction);
    } else {
      StartCoroutine(TouchRoutine());
    }
  }

  protected override IEnumerator TouchRoutine() {
    gm.StartTalking();
    if (gm.mocinhaItem.activeSelf) {
      yield return gm.Talk("Excuse-me, sir...", gm.Bro);
      yield return gm.FadeOut();
      yield return comic2.ShowComic();
      Debug.Log("After Comic2");
      yield return comic3.ShowComic();
      Debug.Log("After Comic3");
      gm.MocinhaBartender.gameObject.SetActive(true);
      gm.mocinhaItem.SetActive(false);
      gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.defaultController;
      gm.Bartender.transform.position = new Vector3(1000, 0, 0);
      yield return gm.FadeIn();
      gm.Bartender.gameObject.SetActive(false);
    } else {
      yield return gm.Talk("He seems too busy for a fist wrestling.", gm.Bro);
    }
    gm.StopTalking();
  }
}