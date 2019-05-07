using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultScreen : MonoBehaviour {

    public GameObject resultScreenUI;
    public Text resultText;
	public Font spFont;
	
	private bool isMultiplayer;
	private bool winScoreReached;
	private bool winMarginReached;
	
    void Start () {
		isMultiplayer = (PlayerPrefs.GetInt("Multiplayer") != 0);
	}

	void Update () {
		winScoreReached = (GameManager.playerScore01 >= 11 || GameManager.playerScore02 >= 11) ? true : false;
		winMarginReached = (Mathf.Abs(GameManager.playerScore01 - GameManager.playerScore02) >= 2 ? true : false);
		if (winScoreReached && winMarginReached) {
			resultScreenUI.SetActive(true);
            Time.timeScale = 0f;
			if (isMultiplayer) {
				resultText.color = new Color32(52, 152, 219, 255);
				if (GameManager.playerScore01 >= 11) {
				    resultText.text = "Player 1 wins!";
				} else {
					resultText.text = "Player 2 wins!";
				}
			} else if (GameManager.playerScore01 >= 10) {
				resultText.text = "YOU DEFEATED";
				resultText.font = spFont;
				resultText.color = new Color32(244, 208, 63, 255);
			} else {
				resultText.text = "YOU DIED";
				resultText.font = spFont;
				resultText.color = new Color32(236, 112, 99, 255);
			}
		}
	}

    public void PlayAgain () {
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void QuitGame () {
		Application.Quit();
	}
}
