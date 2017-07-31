using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLookScript : LookScript {
  public Vector3 interactionPos;
  public int direction;

  public override void Action() {
    gm.player.MoveTo(interactionPos, gameObject, direction);
  }

  private void Update() {
    if (gm != null && gm.movingToInteraction != null && gm.movingToInteraction.gameObject == gameObject && gm.player.move == false) {
      gm.movingToInteraction = null;
      StartCoroutine(LookRoutine());
    }
  }
}