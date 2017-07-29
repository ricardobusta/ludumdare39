using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LookAtCamera : MonoBehaviour {

  void Update() {
    transform.rotation = Camera.main.transform.rotation;
  }
}