using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	
    public GameObject pauseMenuUI;

    private AudioSource bgMusic;

    void Start () {
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
	}

	void Update () {
		// Pause (or resume) the game when escape, P, or enter key is pressed
		if (Input.GetKeyDown(KeyCode.Escape) || 
		    Input.GetKeyDown(KeyCode.P) ||
			Input.GetKeyDown(KeyCode.Return)) {
			if (GameIsPaused) {
				Resume();
			} else {
				Pause();
			}
		}
	}

	public void Resume () {
		// Hide pause menu and restart time
        pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		bgMusic.Play();
		GameIsPaused = false;
	}

	void Pause () {
		// Bring up pause menu and freeze time
        pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		bgMusic.Pause();
		GameIsPaused = true;
	}

    public void Restart() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadMenu() {
		Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
	}
}
