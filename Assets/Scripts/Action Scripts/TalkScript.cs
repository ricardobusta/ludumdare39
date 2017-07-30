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
    StartCoroutine(TalkRoutine());
  }

  protected virtual IEnumerator TalkRoutine() {
    StartTalking();
    yield return Talk("Talk t talk 1", interaction);
    yield return Talk("Talk t talk 2", interaction);
    yield return Talk("Talk t talk 3", interaction);
    StopTalking();
  }

  protected IEnumerator Talk(string text, InteractionScript interaction) {
    gm.speechBubble.Show(text, interaction);
    gm.ResetUserInput();
    while (gm.waitingUserInput) {
      Debug.Log("wait1" + gm.waitingUserInput);
      yield return new WaitForEndOfFrame();
    }
    gm.speechBubble.Hide();
    while (gm.speechBubble.active) {
      Debug.Log("wait2" + gm.speechBubble.active);
      yield return new WaitForEndOfFrame();
    }
  }

  protected void StartTalking() {
    gm.allScreenButton.gameObject.SetActive(true);
    gm.speechBubble.Deactivate();
  }

  protected void StopTalking() {
    gm.allScreenButton.gameObject.SetActive(false);
  }
}