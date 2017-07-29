using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public float power;
  public float happy;

  [Header("Ref")]
  public Slider powerSlider;
  public Slider happySlider;

  void Start() {
    happy = 0.5f;
    power = 0.5f;
  }

  void Update() {
    power -= 0.1f * Time.deltaTime;

    UpdateSliders();
  }

  void UpdateSliders() {
    powerSlider.value = power;
    happySlider.value = happy;
  }
}
