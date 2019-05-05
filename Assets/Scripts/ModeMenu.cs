using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeMenu : MonoBehaviour {

	public void Start1P () {
		PlayerPrefs.SetInt("Multiplayer", (false ? 1 : 0));
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void Start2P () {
		PlayerPrefs.SetInt("Multiplayer", (true ? 1 : 0));
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
