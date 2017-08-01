using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkMimiTormento : MoveToTalkScript {
  public ComicManager comic1;
  public ComicManager comic2;
  public ComicManager comic3;

  protected override IEnumerator TalkRoutine() {
    gm.StartTalking();
    yield return gm.FadeOut();
    yield return comic1.ShowComic();
    yield return comic2.ShowComic();
    yield return comic3.ShowComic();

    gm.MimiTormento.transform.position = new Vector3(1000, 0, 0);
    gm.MimiEntediada.gameObject.SetActive(true);
    yield return gm.FadeIn();
    gm.MimiTormento.gameObject.SetActive(false);

    gm.StopTalking();
  }
}