using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private float distance;
	public GameObject player;
	private float rand;
	private float speed = 2f;
	private bool isWall = false;
	private string dir = null;
	public bool isSlash = false;
	public float health = 3.75f;

	void Start () {
		switch (Random.Range (1, 2)) {
			case 1:
				dir = "L";
				break;
			case 2:
				dir = "R";
				break;
		}
	}
	

	void Update () {
		distance = Vector3.Distance (this.transform.position, player.transform.position);
		//print (distance);

		if (distance <= 5 && player.transform.position.y <= this.transform.position.y) {
			/*if (distance <= 2) {
				if (!isSlash) {
					isSlash = true;
					print ("SWORD");
				}
			} else {*/
				for (int i = 0; i <= 4; i++) {
					if (player.transform.position.x + 2 <= this.transform.position.x) {
						transform.rotation = Quaternion.Euler (0, 180, 0);
						this.transform.Translate (1.0f * Time.deltaTime, 0, 0);
					} else if (this.transform.position.x <= player.transform.position.x - 2) {
						transform.rotation = Quaternion.Euler (0, 0, 0);
						this.transform.Translate (1.0f * Time.deltaTime, 0, 0);
					} else {
						this.transform.Translate (0, 0, 0);
					}
				}
		} else {
			//WANDER
			rand = Random.Range(0, 100);
			if (rand >= 99) {
				rand = Random.Range (1, 10);

				switch (dir) {
					case "L":
						StopAllCoroutines ();
						transform.rotation = Quaternion.Euler (0, 180, 0);
						StartCoroutine (RandLeft());
						break;
					case "R":
						StopAllCoroutines ();
						transform.rotation = Quaternion.Euler (0, 0, 0);
						StartCoroutine(RandRight());
						break;
				}

				print (dir);

				if (rand <= 5) {
					dir = "R";
				} else  if (rand > 5) {
					dir = "L";
				}
			}
		}

		if (isWall) {
			StopAllCoroutines ();
			if (dir == "R") {
				dir = "L";
				transform.Translate (-1, 0, 0);
				//print ("SWITCHL");
				isWall = false;
			} else if (dir == "L") {
				dir = "R";
				transform.Translate (1, 0, 0);
				//print ("SWITCHR");
				isWall = false;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "SideCollide") {
			//print ("poop");
			isWall = true;
		}
		if (other.gameObject.tag == "PSword") {
			health -= .9375f;
		}
	}

	IEnumerator RandLeft () {
		float lerp = 0f;
		float distance = 1f;
		float time = distance / speed;
		dir = "L";

		Vector3 startPos = transform.position;
		Vector3 endPos = startPos + Vector3.left * distance;

		while (lerp < 1f) {
			transform.position = Vector3.Lerp (startPos, endPos, lerp);

			lerp += Time.deltaTime / time;
			yield return null;
		}

		//print ("STOPL");
		StopAllCoroutines ();
	}

	IEnumerator RandRight () {
		float lerp = 0f;
		float distance = 1f;
		float time = distance / speed;
		dir = "R";

		Vector3 startPos = transform.position;
		Vector3 endPos = startPos + Vector3.right * distance;

		while (lerp < 1f) {
			transform.position = Vector3.Lerp (startPos, endPos, lerp);

			lerp += Time.deltaTime / time;
			yield return null;
		}

		//print ("STOPR");
		StopAllCoroutines ();
	}
		
	public void TurnOffSword() {
		isSlash = false;
	}
}
