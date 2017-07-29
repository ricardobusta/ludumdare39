using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LookAtCamera : MonoBehaviour {

  Camera cam;

  // Use this for initialization
  void Start() {
    cam = FindObjectOfType<Camera>();
  }

  // Update is called once per frame
  void Update() {
    transform.localRotation = cam.transform.rotation;
  }
}
