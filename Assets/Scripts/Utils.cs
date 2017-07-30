using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {
  static RectTransform canvasTransform;

  public static void Initialize() {
    canvasTransform = GameObject.FindObjectOfType<Canvas>().GetComponent<RectTransform>();
  }

  public static Vector2 WorldToCanvas(Vector3 pos) {
    Vector2 p = Camera.main.WorldToViewportPoint(pos) - (0.5f * Vector3.one);
    return Vector2.Scale(p, canvasTransform.sizeDelta);
  }
}