using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl: MonoBehaviour {

    public float speed = 120;

    private AudioSource hitSound;
    private Rigidbody2D rigidBody;

	void Start () {
		// Get hit sound and rigidbody of ball
		hitSound = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody2D>();
		// Pause for 2 seconds, then call the "GoBall" function
		Invoke("GoBall", 2.0f);
	}

    void Update () {
		float xVel = rigidBody.velocity.x;
		if (xVel < 18 && xVel > -18 && xVel != 0) {
			if (xVel > 0) {
				rigidBody.velocity = new Vector2(20, rigidBody.velocity.y);
			} else {
				rigidBody.velocity = new Vector2(-20, rigidBody.velocity.y);
			}
			//Debug.Log("Velocity before: " + xVel);
			//Debug.Log("Velocity after: " + rigidBody.velocity.x);
		}
	}

	void OnCollisionEnter2D (Collision2D colInfo) {
		// Determine velocity of ball when it hits a player
		if (colInfo.collider.tag == "Player") {
			rigidBody.velocity = new Vector2(
				rigidBody.velocity.x, 
				rigidBody.velocity.y/2 + 
				colInfo.collider.GetComponent<Rigidbody2D>().velocity.y/3);
			// Play the hit sound (with slight pitch variation)
			hitSound.pitch = Random.Range(0.8f, 1.2f);
			hitSound.Play();
		}
	}

	void GoBall () {
		// Choose a side to propel the ball at random
		float randomNumber = Random.Range(0, 2);
		if (randomNumber <= 0.5) {
			rigidBody.AddForce(new Vector2(speed, 10));
		} else {
			rigidBody.AddForce(new Vector2(-speed, -10));
		}
	}

	void ResetBall () {
		// Remove any ball velocity and return it to the center
		rigidBody.velocity = new Vector2(0, 0);
		transform.position = new Vector2(0, 0);

        // Pause for 0.5 seconds, then call the "GoBall" function
		Invoke("GoBall", 0.5f);
	}
}