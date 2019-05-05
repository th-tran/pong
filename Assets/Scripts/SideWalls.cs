using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

    private AudioSource scoreSound;

    void Start () {
        scoreSound = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball") {
			string wallName = transform.name;
			GameManager.Score(wallName);
			scoreSound.Play();
			hitInfo.gameObject.SendMessage("ResetBall");
		}
	}
}