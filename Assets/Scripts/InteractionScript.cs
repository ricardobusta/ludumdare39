using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {
  public Vector3 interactionPos;

  GameManager gm;

  private void Start() {
    gm = GameManager.instance;
  }

  public void Interact() {
    Debug.Log(name + " interacted");

    gm.player.MoveTo(interactionPos);
  }

  public virtual void ActionTalk() {

  }

  public virtual void ActionTouch() {

  }

  public virtual void ActionLook() {

  }

  private void Update() {
    if (gm.movingToInteraction == this && !gm.player.move) {
    }
  }
}