using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

  Collider col;
  GameManager gm;

  private void Start() {
    gm = GameManager.instance;

    col = GetComponent<Collider>();
  }

  private void OnMouseDown() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    // Check for 2D object blocking ray
    RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
    if (hit2D.collider != null) {
      Debug.Log("hit 2D");
      return;
    }

    // Hit the ground

    RaycastHit hitInfo;
    bool hit = col.Raycast(ray, out hitInfo, 1000.0f);
    if (hit) {
      Debug.Log("Walk");
      gm.movingToInteraction = null;
      gm.player.MoveTo(hitInfo.point);
    }
  }
}