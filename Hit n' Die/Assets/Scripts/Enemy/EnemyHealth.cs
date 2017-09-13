using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	private Enemy enemyParent;

	void Start () {
		enemyParent = GetComponentInParent<Enemy>();
	}

	void Update () {
		this.transform.localScale = new Vector3 (enemyParent.health, .22f, .375f);
	}
}
