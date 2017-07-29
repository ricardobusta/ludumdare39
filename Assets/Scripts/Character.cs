using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

  public Vector3 destiny;

  public float speed = 1;

  private void Start() {
    destiny = transform.position;
  }

  void Update() {
    Vector3 pos = transform.position;
    float distance = speed * Time.deltaTime;
    if (Vector3.Distance(pos, destiny) > distance) {
      transform.position += Vector3.Normalize(destiny - pos) * distance;
    } else {
      transform.position = pos;
    }
  }
}