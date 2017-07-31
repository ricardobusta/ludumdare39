using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGetMocinha : MoveToTouchScript {

  protected override IEnumerator TouchRoutine() {
    gm.StartTalking();
    yield return gm.Talk("Come with me!", gm.Bro);

    this.enabled = false;
    gm.player.MoveTo(gm.MocinhaBebada.transform.position, gm.MocinhaBebada.gameObject, -1);
    while (gm.player.move) {
      yield return new WaitForEndOfFrame();
    }
    Debug.Log("Wat0");
    gm.MocinhaBebada.gameObject.SetActive(false);
    Debug.Log("Wat1");
    gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.mocinhaController;
    Debug.Log("Wat2");
    gm.mocinhaItem.SetActive(true);
    Debug.Log("Wat3");
    gm.StopTalking();
  }
}