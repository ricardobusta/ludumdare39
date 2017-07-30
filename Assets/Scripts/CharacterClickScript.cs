using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CharacterClickScript : MonoBehaviour {

  InteractionScript interaction;
  GameManager gm;

  void Start() {
    if (transform.parent == null) {
      Debug.LogError(name + " must have parent Interaction");
      return;
    }

    gm = GameManager.instance;

    interaction = transform.parent.GetComponent<InteractionScript>();
    if (interaction == null) {
      Debug.LogError(transform.parent.name + " must have interaction script");
    }
  }

  private void OnMouseDown() {
    interaction.Interact();
  }

#if (UNITY_EDITOR)
  private void Update() {
    transform.localPosition = Vector3.Scale(Vector3.up, transform.localPosition);
  }
#endif
}