using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	static int playerScore01;
	static int playerScore02;

	public GUISkin theSkin;

	public Transform theBall;

	void Start () {
		playerScore01 = 0;
		playerScore02 = 0;
		theBall = GameObject.FindGameObjectWithTag("Ball").transform;
	}

	public static void Score (string wallName) {
		if (wallName == "rightWall") {
			playerScore01++;
		} else {
			playerScore02++;
		}
	}

	void OnGUI () {
		GUI.skin = theSkin;
		GUI.Label(new Rect(Screen.width/2 - 150, 20, 100, 100), "" + playerScore01);
		GUI.Label(new Rect(Screen.width/2 + 150, 20, 100, 100), "" + playerScore02);

		/*if (GUI.Button(new Rect(Screen.width/2 - 121/2, 35, 121, 53), "RESET")) {
			playerScore01 = 0;
			playerScore02 = 0;

			theBall.gameObject.SendMessage ("ResetBall");
		}*/
	}
}