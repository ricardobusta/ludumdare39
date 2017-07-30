using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractiveMenu : MonoBehaviour {

  GameManager gm;
  InteractionScript script = null;
  public Button talkButton;
  public Button touchButton;
  public Button lookButton;


  private void Start() {
    gm = GameManager.instance;
    gameObject.SetActive(false);
  }

  public void Activate(InteractionScript s) {
    if (s == null) {
      return;
    }
    script = s;
    gameObject.SetActive(true);

    transform.localPosition = Utils.WorldToCanvas(script.MenuPosition());
    gm.closeMenusButton.gameObject.SetActive(true);

    Animator anim = GetComponent<Animator>();
    anim.SetTrigger("Toggle");
  }

  public void Deactivate() {
    ClearButtons();
    script = null;
  }

  public void ShowButtonsAfterAnim() {
    talkButton.enabled = true;
    lookButton.enabled = true;
    touchButton.enabled = true;
    gm.closeMenusButton.enabled = true;
  }

  public void ClearButtons() {
    gm.closeMenusButton.enabled = false;
    Animator anim = GetComponent<Animator>();
    anim.SetTrigger("Toggle");
  }

  public void SetInactiveAfterAnim() {
    gameObject.SetActive(false);
    gm.closeMenusButton.gameObject.SetActive(false);
  }

  public void Talk() {
    if (script == null) {
      return;
    }
    ClearButtons();
    script.talk.Action();
    script = null;
  }

  public void Touch() {
    if (script == null) {
      return;
    }
    ClearButtons();
    script.touch.Action();
    script = null;
  }

  public void Look() {
    if (script == null) {
      return;
    }
    ClearButtons();
    script.look.Action();
    script = null;
  }
}