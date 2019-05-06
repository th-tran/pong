using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls: MonoBehaviour {

    public KeyCode moveUp;
    public KeyCode moveDown;
	
    public float speed = 10;

    private Rigidbody2D rigidBody;

    void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

    void Update() {
        // Move up, down, or stop based on pressed keys
        if (Input.GetKey(moveUp)) {
            rigidBody.velocity = new Vector2(0, speed);
        } else if (Input.GetKey(moveDown)) {
            rigidBody.velocity = new Vector2(0, -speed);
        } else {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }
}