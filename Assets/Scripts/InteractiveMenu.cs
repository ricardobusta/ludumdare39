using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveMenu : MonoBehaviour {

  GameManager gm;
  EventSystem eventSystem;

  InteractionScript script = null;
  RectTransform canvasTransform;


  private void Start() {
    gm = GameManager.instance;
    eventSystem = FindObjectOfType<EventSystem>();
    canvasTransform = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
    if (canvasTransform == null) {
      Debug.Log("Must have a Canvas");
    }
    gameObject.SetActive(false);
  }

  public void Activate(InteractionScript s) {
    if (s == null) {
      return;
    }
    script = s;
    gameObject.SetActive(true);

    transform.localPosition = WorldToCanvas(script.MenuPosition());
    Animator anim = GetComponent<Animator>();
    anim.SetTrigger("Toggle");
  }

  public void Deactivate() {
    ClearButtons();
    ClearScript();
  }

  public void ClearButtons() {
    Animator anim = GetComponent<Animator>();
    anim.SetTrigger("Toggle");
  }

  public void ClearScript() {
    script = null;
  }

  public void SetInactive() {
    gameObject.SetActive(false);
  }

  public void Talk() {
    if (script == null) {
      return;
    }
    ClearButtons();
    script.talk.Action();
    ClearScript();
  }

  public void Touch() {
    if (script == null) {
      return;
    }
    ClearButtons();
    script.touch.Action();
    ClearScript();
  }

  public void Look() {
    if (script == null) {
      return;
    }
    ClearButtons();
    script.look.Action();
    ClearScript();
  }

  Vector2 WorldToCanvas(Vector3 pos) {
    Vector2 p = Camera.main.WorldToViewportPoint(pos) - (0.5f * Vector3.one);
    Debug.Log(p + " " + canvasTransform.sizeDelta);
    return Vector2.Scale(p, canvasTransform.sizeDelta);
  }
}