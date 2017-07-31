using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour {
  public Animator animator;
  public Text text;
  public Button button;
  public bool active { get; private set; }

  private void Start() {
    if (animator == null) {
      Debug.LogError(name + " must have an animator");
    }
    if (text == null) {
      Debug.LogError(name + " must have a text");
    }
  }

  public void Show(string s, InteractionScript chara) {
    active = true;
    text.text = s;
    gameObject.SetActive(true);
    gameObject.transform.localPosition = chara.MenuPosition();
    animator.SetTrigger("Toggle");
  }

  public void Hide() {
    button.interactable = false;
    animator.SetTrigger("Toggle");
  }

  public void Activate() {
    button.interactable = true;
  }

  public void Deactivate() {
    active = false;
  }
}