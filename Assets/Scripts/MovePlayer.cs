using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

  public Character player;
  Collider col;

  private void Start() {
    col = GetComponent<Collider>();
  }

  private void OnMouseDown() {
    Debug.Log("worked");

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitInfo;
    bool hit = col.Raycast(ray, out hitInfo, 1000.0f);
    if (hit) {
      player.destiny = hitInfo.point;
    }
  }
}