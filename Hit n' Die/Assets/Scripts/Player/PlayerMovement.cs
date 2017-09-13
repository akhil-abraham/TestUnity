using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//Set up vars
	float moveSpeed = .75f;
	public int jumpForce = 10;
	private bool canJump = false;
	private Rigidbody selfRigidbody;
	private bool isGrounded = false;
	public static float pHealth = 5f;
	public static bool isSlash = false;

	public PlayerSword sword;

	// Use this for initialization
	void Start () {
		selfRigidbody = GetComponent<Rigidbody> ();
		Physics.gravity = new Vector3 (0, -25, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("left") && !Input.GetKey("right")) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
			selfRigidbody.AddForce (-moveSpeed, 0, 0, ForceMode.Impulse);
		} else if (Input.GetKey ("right") && !Input.GetKey("left")) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			selfRigidbody.AddForce (moveSpeed, 0, 0, ForceMode.Impulse);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!isSlash) {
				isSlash = true;
			}
		}
			
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if (isGrounded) {
				canJump = true;
			} else {
				canJump = false;
			}
		}

		if(canJump){
			selfRigidbody.AddForce(0,jumpForce,0, ForceMode.Impulse);
			canJump = false;
		}
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Collider") {
			isGrounded = true;
			//print ("onground");
			moveSpeed = .75f;
		} else if (other.gameObject.tag == "Enemy") {
			pHealth -= 1.25f;
		}
	}

	void OnCollisionExit (Collision other) {
		if (other.gameObject.tag == "Collider") {
			isGrounded = false;
			//print ("offground");
			moveSpeed = .20f;
		}
	}

	public static void DoneSlash () {
		isSlash = false;
		//sword.anim.ResetTrigger ("pisSlash");
		print (isSlash);
	}
}