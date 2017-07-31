using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMocinha : MoveToTouchScript {

  public override IEnumerator TouchRoutine() {
    gm.StartTalking();
    yield return gm.Talk("Come with me", gm.Bro);
    gm.MocinhaBebada.gameObject.SetActive(false);
    gm.BroAnim.animator.runtimeAnimatorController = gm.BroAnim.mocinhaController;
    gm.mocinhaItem.SetActive(true);
    gm.player.MoveTo(gm.MocinhaBebada.transform.position, gm.MocinhaBebada.gameObject, -1);
    gm.StopTalking();
  }
}