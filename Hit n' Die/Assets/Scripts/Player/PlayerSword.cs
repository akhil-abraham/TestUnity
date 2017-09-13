using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour {

	public static Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (PlayerMovement.isSlash) {
			anim.SetTrigger ("pisSlash");
			PlayerMovement.DoneSlash ();
		}
	}
}
