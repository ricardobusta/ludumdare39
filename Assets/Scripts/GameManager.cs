using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  const float totalPower = 240;
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
  public Image fadeImage;

  [Header("Characters")]
  public PlayerMovingAnimation BroAnim;
  public InteractionScript Bro;
  public InteractionScript MocinhaBebada;
  public InteractionScript Bartender;
  public InteractionScript MocinhaBartender;
  public InteractionScript Mocinho;
  public InteractionScript MocinhoBebado;
  public InteractionScript MocinhoMolhado;
  public InteractionScript MocinhoDancando;
  public InteractionScript Bucket;
  public InteractionScript Nina;
  public InteractionScript MimiTormento;
  public InteractionScript MimiEntediada;
  public InteractionScript MimiFeliz;
  public InteractionScript DJ;

  [Header("Inventory")]
  public GameObject mocinhaItem;
  public GameObject beerItem;
  public GameObject bucketItem;

  [Header("Comics")]
  public ComicManager[] cm;
  public ComicManager[] intro;

  bool started = false;

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

    power = totalPower;

    if (interactiveMenu == null) {
      Debug.LogError("Must have an interactive menu");
    }

    fadeImage.gameObject.SetActive(false);

    MocinhaBartender.gameObject.SetActive(false);
    MocinhoBebado.gameObject.SetActive(false);
    MocinhoMolhado.gameObject.SetActive(false);
    Nina.gameObject.SetActive(false);
    MocinhoDancando.gameObject.SetActive(false);
    MimiEntediada.gameObject.SetActive(false);
    MimiFeliz.gameObject.SetActive(false);

    foreach (ComicManager c in cm) {
      c.gameObject.SetActive(true);
    }
    foreach (ComicManager c in intro) {
      c.gameObject.SetActive(true);
    }

    StartCoroutine(IntroRoutine());
  }

  void Update() {
    if (!started) {
      return;
    }
    power -= Time.deltaTime;

    UpdateSliders();
  }

  void UpdateSliders() {
    powerSlider.value = power / totalPower;

    if (power <= 0) {
      StartCoroutine(GameOverRoutine());
    }
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
    started = true;
    Debug.Log("Fade In");
    const float timeTotal = 0.5f;
    float time = 0;
    Color c = Color.white;
    while (time < timeTotal) {
      time += Time.deltaTime;
      c.a = 1 - time / timeTotal;
      Debug.Log(c.a);
      fadeImage.color = c;
      yield return new WaitForEndOfFrame();
    }
    c.a = 0;
    fadeImage.color = c;
    fadeImage.gameObject.SetActive(false);
  }

  public IEnumerator FadeOut() {
    started = false;
    Debug.Log("Fade Out");
    fadeImage.gameObject.SetActive(true);
    const float timeTotal = 0.5f;
    float time = 0;
    Color c = Color.white;
    while (time < timeTotal) {
      time += Time.deltaTime;
      c.a = time / timeTotal;
      fadeImage.color = c;
      Debug.Log(c.a);
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

  IEnumerator IntroRoutine() {
    allScreenButton.gameObject.SetActive(true);
    allScreenButton.interactable = true;
    fadeImage.gameObject.SetActive(true);
    fadeImage.color = Color.white;
    yield return new WaitForEndOfFrame();
    yield return intro[0].ShowComic();
    yield return intro[1].ShowComic();
    yield return intro[2].ShowComic();
    yield return intro[3].ShowComic();
    yield return intro[4].ShowComic();
    allScreenButton.gameObject.SetActive(false);
    yield return FadeIn();
    started = true;
  }

  public IEnumerator GameOverRoutine() {
    yield return FadeOut();
    SceneManager.LoadScene("GameOverScreen");
  }
}