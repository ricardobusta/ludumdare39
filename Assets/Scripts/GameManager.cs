using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public float power;

  public static GameManager instance { get; private set; }
  public Character player;
  public InteractionScript movingToInteraction;

  [Header("Ref")]
  public Slider powerSlider;
  public Button closeMenusButton;
  public InteractiveMenu interactiveMenu;
  public SpeechBubble speechBubble;
  public Button allScreenButton;
  public bool waitingUserInput { get; private set; }

  private void Awake() {
    instance = this;
    if (player == null) {
      Debug.LogError(name + " player must not be null");
    }
    if (closeMenusButton == null) {
      Debug.LogError(name + " must have a close menus button");
    }
    closeMenusButton.gameObject.SetActive(false);
    if (allScreenButton == null) {
      Debug.LogError(name + " must have an all screen button");
    }
    allScreenButton.gameObject.SetActive(false);

    speechBubble.gameObject.SetActive(false);

    waitingUserInput = true;
  }

  void Start() {
    Utils.Initialize();

    power = 1;

    if (interactiveMenu == null) {
      Debug.LogError("Must have an interactive menu");
    }
  }

  void Update() {
    power -= 0.1f * Time.deltaTime;

    UpdateSliders();
  }

  void UpdateSliders() {
    powerSlider.value = power;
  }

  public void CloseMenus() {
    if (interactiveMenu.gameObject.activeSelf) {
      interactiveMenu.Deactivate();
    }
  }

  public void ResetUserInput() {
    waitingUserInput = true;
    Debug.Log("Reset");
  }

  public void AllScreenButton() {
    waitingUserInput = false;
    Debug.Log("All Button Press");
  }
}