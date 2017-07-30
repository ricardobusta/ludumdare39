using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkScript : MonoBehaviour {
  protected GameManager gm;
  protected InteractionScript interaction;

  private void Start() {
    gm = GameManager.instance;
    interaction = GetComponent<InteractionScript>();
  }

  public virtual void Action() {
    Debug.Log("Talk");
  }
}