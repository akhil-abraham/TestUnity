using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour {

	private Animator anim;
	private Enemy enemyParent;

	void Start () {
		anim = GetComponent<Animator> ();
		enemyParent = GetComponentInParent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyParent.isSlash) {
			anim.SetTrigger ("Slash");
			enemyParent.TurnOffSword ();
		}
	}
}
