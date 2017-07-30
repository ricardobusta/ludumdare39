using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Character : MonoBehaviour {

  Vector3 destiny;
  public float speed = 1;
  public bool move { get; private set; }
  public int direction;
  SpriteRenderer sprite;
  GameManager gm;

  private void Start() {
    gm = GameManager.instance;
    sprite = GetComponentInChildren<SpriteRenderer>();
    if (sprite == null) {
      Debug.LogError("Character " + name + " must have a sprite renderer.");
    }

    move = false;
    Vector3 p = transform.position;
    p.y = 0;
    transform.position = p;
    sprite.flipX = direction > 0;
    destiny = transform.position;
  }

  void Update() {
    if (move) {
      Vector3 pos = transform.position;
      float distance = speed * Time.deltaTime;
      if (Vector3.Distance(pos, destiny) > distance) {
        transform.position += (Vector3.Normalize(destiny - pos) * distance);
        direction = (int)Mathf.Sign(destiny.x - pos.x);
      } else {
        transform.position = pos;
        move = false;
      }
      sprite.flipX = direction > 0;
    }
#if (UNITY_EDITOR)
    else {
      Vector3 p = transform.position;
      p.y = 0;
      transform.position = p;
      sprite.flipX = direction > 0;
    }
#endif
  }

  public void MoveTo(Vector3 position, InteractionScript interaction) {
    destiny = position;
    gm.movingToInteraction = interaction;
    move = true;
  }
}