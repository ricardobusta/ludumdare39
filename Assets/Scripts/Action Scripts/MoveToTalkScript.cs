using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTalkScript : TalkScript {
  public Vector3 interactionPos;
  public int direction;

  public override void Action() {
    gm.player.MoveTo(interactionPos, interaction, direction);
  }

  private void Update() {
    Debug.Log(gm.movingToInteraction + " " + gm.player.move);
    if (gm.movingToInteraction != null && gm.movingToInteraction.gameObject == gameObject && gm.player.move == false) {
      gm.movingToInteraction = null;
    }
  }
}