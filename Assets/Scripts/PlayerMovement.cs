using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 50;
	public GameObject deathParticles;

	private float maxSpeed = 5f;
	private Vector3 input;
	private Rigidbody rigidBody;

	private Vector3 spawn;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		if (rigidBody.velocity.magnitude < maxSpeed) {
			rigidBody.AddRelativeForce (input * moveSpeed);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.transform.tag == "Enemy" || other.transform.tag == "KillZone") {
			Die ();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Goal") {
			GameManger.CompleteLevel ();
		}
	}

	void Die() {
		Instantiate (deathParticles, transform.position, Quaternion.Euler(270, 0, 0));
		transform.position = spawn;
	}


}
