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

  public Button closeMenusButton;

  [Header("Ref")]
  public Slider powerSlider;
  public Slider happySlider;

  private void Awake() {
    instance = this;
    if (player == null) {
      Debug.LogError(name + " player must not be null");
    }
    if (closeMenusButton == null) {
      Debug.LogError(name + " must have a close menus button");
    }
    closeMenusButton.gameObject.SetActive(false);
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

  public void CloseMenus() {
    if (interactiveMenu.gameObject.activeSelf) {
      interactiveMenu.Deactivate();
    }
  }
}