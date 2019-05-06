using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour {

    public float speed = 10;
	public float lerpSpeed = 1f;

    private Transform theBall;
    private Rigidbody2D rigidBody;
	
    void Start () {
		// Get ball and rigidbody of AI
		theBall = GameObject.FindGameObjectWithTag("Ball").transform;
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update () {
		// Determine movement of AI based on distance from the ball
		float diff = theBall.position.y - transform.position.y;
		if (diff > 0) {
			rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.up * speed, lerpSpeed * Time.deltaTime);	
        } else if (diff < 0) {
			rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.down * speed, lerpSpeed * Time.deltaTime);
        } else {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero * speed, lerpSpeed * Time.deltaTime);
        }
	}

	public void ToggleState() {
		// Turn AI on or off
		GetComponent<AIControls>().enabled = !GetComponent<AIControls>().enabled;
	}
}
