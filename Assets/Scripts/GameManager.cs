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

  public InteractiveMenu interactiveMenu { get; private set; }

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

    if (interactiveMenu == null) {
      interactiveMenu = FindObjectOfType<InteractiveMenu>();
    }
  }

  void Update() {
    power -= 0.1f * Time.deltaTime;

    UpdateSliders();
  }

  void UpdateSliders() {
    powerSlider.value = power;
    happySlider.value = happy;
  }

  void CloseInteractiveMenu() {

  }
}