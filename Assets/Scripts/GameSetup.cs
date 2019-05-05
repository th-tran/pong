using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameSetup : MonoBehaviour {

	public Camera mainCam;

	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D leftWall;
	public BoxCollider2D rightWall;

	public Transform Player01;
	public Transform Player02;

    public AudioClip spTrack;
	public AudioClip mpTrack;

    private AudioSource bgMusic;
	private bool isMultiplayer;

	void Start () {
        bgMusic = this.GetComponent<AudioSource>();
		isMultiplayer = (PlayerPrefs.GetInt("Multiplayer") != 0);
		if (isMultiplayer) {
			Player02.GetComponent<AIControls>().enabled = false;
			Player02.GetComponent<PlayerControls>().enabled = true;
			bgMusic.clip = mpTrack;
			bgMusic.Play();
		} else {
			Player02.GetComponent<PlayerControls>().enabled = false;
			Player02.GetComponent<AIControls>().enabled = true;
			bgMusic.clip = spTrack;
			bgMusic.Play();
		}
		// Move each wall to its edge location
		topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

		bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		bottomWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

		leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

		rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        // Move each player to their starting location
        Player01.position = mainCam.ScreenToWorldPoint(new Vector3(75f, Screen.height/2, 10f));
		Player02.position = mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, Screen.height/2, 10f));

        // Modify the x-coordinates of Players only
        /*Vector3 temp01 = Player01.position;
		temp01.x = mainCam.ScreenToWorldPoint(new Vector3(75f, Screen.height/2, 10f)).x;
        Player01.position = temp01;

		Vector3 temp02 = Player02.position;
		temp02.x = mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, Screen.height/2, 10f)).x;
        Player02.position = temp02;*/
	}
}
