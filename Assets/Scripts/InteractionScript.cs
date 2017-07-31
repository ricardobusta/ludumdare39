using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {
  GameManager gm;

  [HideInInspector]
  public TalkScript talk;
  [HideInInspector]
  public TouchScript touch;
  [HideInInspector]
  public LookScript look;

  public float menuHeight;


  private void Start() {
    gm = GameManager.instance;

    talk = GetComponent<TalkScript>();
    if (talk == null) {
      Debug.LogError(name + " must have a Talk Script");
    }
    touch = GetComponent<TouchScript>();
    if (touch == null) {
      Debug.LogError(name + " must have a Touch Script");
    }
    look = GetComponent<LookScript>();
    if (look == null) {
      Debug.LogError(name + " must have a Look Script");
    }
  }

  public void Interact() {
    if (gm.interactiveMenu.gameObject.activeSelf || gm.allScreenButton.gameObject.activeSelf) {
      return;
    }
    StartCoroutine(OpenMenu());
  }

  IEnumerator OpenMenu() {
    gm.interactiveMenu.Activate(this);
    yield return null;
  }

  public Vector2 MenuPosition() {
    return Utils.WorldToCanvas(transform.position + (Vector3.up * menuHeight * 0.1f));
  }
}