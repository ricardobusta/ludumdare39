using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingAnimation : MonoBehaviour {

  public Animator animator;
  public Character character;

  public RuntimeAnimatorController defaultController;
  public RuntimeAnimatorController mocinhaController;
  public RuntimeAnimatorController cervejaController;
  public RuntimeAnimatorController bucketController;

  void Update() {
    animator.SetBool("Moving", character.move);
  }
}