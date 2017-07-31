using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public float power;

  public static GameManager instance { get; private set; }
  public Character player;
  public GameObject movingToInteraction;

  public enum Language {
    EN_US,
    PT_BR
  };

  public Language language;

  [Header("Ref")]
  public Slider powerSlider;
  public Button closeMenusButton;
  public InteractiveMenu interactiveMenu;
  public SpeechBubble speechBubble;
  public Button allScreenButton;
  private bool waitingUserInput;
  public Image fadeImage { get; private set; }

  [Header("Characters")]
  public PlayerMovingAnimation BroAnim;
  public InteractionScript Bro;
  public InteractionScript MocinhaBebada;
  public InteractionScript Bartender;
  public InteractionScript MocinhaBartender;
  public InteractionScript Mocinho;
  public InteractionScript MocinhoBebado;
  public InteractionScript Bucket;

  [Header("Inventory")]
  public GameObject mocinhaItem;
  public GameObject beerItem;
  public GameObject bucketItem;

  private void Awake() {
    instance = this;

    string lang = PlayerPrefs.GetString("language", "EN_US");
    switch (lang) {
      case "PT_BR":
        language = Language.PT_BR;
        break;
      default:
        language = Language.EN_US;
        break;
    }

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

    MocinhaBartender.gameObject.SetActive(false);
    MocinhoBebado.gameObject.SetActive(false);
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

  public IEnumerator WaitUserInput() {
    ResetUserInput();
    while (waitingUserInput) {
      yield return new WaitForEndOfFrame();
    }
  }

  void ResetUserInput() {
    waitingUserInput = true;
    Debug.Log("Reset");
  }

  public IEnumerator FadeIn() {
    const float timeTotal = 3;
    float time = 0;
    Color c = Color.white;
    while (time < timeTotal) {
      time += Time.deltaTime;
      c.a = 1 - time / timeTotal;
      fadeImage.color = c;
      yield return new WaitForEndOfFrame();
    }
    c.a = 0;
    fadeImage.color = c;
  }

  public IEnumerator FadeOut() {
    const float timeTotal = 3;
    float time = 0;
    Color c = Color.white;
    while (time < timeTotal) {
      time += Time.deltaTime;
      c.a = time / timeTotal;
      fadeImage.color = c;
      yield return new WaitForEndOfFrame();
    }
    c.a = 1;
    fadeImage.color = c;
  }

  public void AllScreenButton() {
    waitingUserInput = false;
    Debug.Log("All Button Press");
  }

  public IEnumerator Talk(string text, InteractionScript interaction) {
    Debug.Log("Talk Call " + text);
    speechBubble.Show(text, interaction);
    yield return WaitUserInput();
    speechBubble.Hide();
    while (speechBubble.gameObject.activeSelf) {
      yield return new WaitForEndOfFrame();
    }
  }

  public void StartTalking() {
    allScreenButton.gameObject.SetActive(true);
    speechBubble.Deactivate();
  }

  public void StopTalking() {
    allScreenButton.gameObject.SetActive(false);
  }
}