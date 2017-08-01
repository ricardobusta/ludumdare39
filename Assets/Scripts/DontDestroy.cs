using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
  private void Awake() {
    if (FindObjectOfType<AudioSource>() != null) {
      DontDestroyOnLoad(gameObject);
    } else {
      DestroyObject(gameObject);
    }
  }
}