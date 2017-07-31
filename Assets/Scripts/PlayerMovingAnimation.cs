using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingAnimation : MonoBehaviour {

  public Animator animator;
  public Character character;

  void Update() {
    animator.SetBool("Moving", character.move);
  }
}