using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public float power;
  public float happy;

  public static GameManager instance { get; private set; }
  public Character player;
  public InteractionScript movingToInteraction;

  [Header("Ref")]
  public Slider powerSlider;
  public Slider happySlider;

  private void Awake() {
    instance = this;
    if (player == null) {
      Debug.LogError(name + " player must not be null");
    }
  }

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