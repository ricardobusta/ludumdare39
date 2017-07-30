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
    if (gm.closeMenusButton.gameObject.activeSelf || gm.allScreenButton.gameObject.activeSelf) {
      return;
    }

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    // Check for 2D object blocking ray
    RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
    if (hit2D.collider != null) {
      return;
    }

    // Hit the ground

    RaycastHit hitInfo;
    bool hit = col.Raycast(ray, out hitInfo, 1000.0f);
    if (hit) {
      gm.movingToInteraction = null;
      gm.player.MoveTo(hitInfo.point, null);
    }
  }
}