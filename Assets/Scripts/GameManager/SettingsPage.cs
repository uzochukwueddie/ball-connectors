using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsPage : MonoBehaviour {

	private DontDestroyMusic music;

	public Text sfxText;
	public Text musicText;

	void Start() {
		music = GameObject.FindObjectOfType<DontDestroyMusic>();
		changeText();
	}

	void Update() {
		changeText();
	}

	void changeText () {
		if (PlayerPrefs.GetInt("SFX") == 0) {
			sfxText.text = "ON";
			//PlayerPrefs.Save ();
		} else {
			sfxText.text = "OFF";
			//PlayerPrefs.Save ();
		}

		if (PlayerPrefs.GetInt("Muted") == 0) {
			musicText.text = "ON";
		} else {
			musicText.text = "OFF";
		}
	}

	public void HomePage() {
		ButtonPressedSound.instance.PlayButtonSound();
		SceneManager.LoadScene("Main Menu Scene");
	}
	
	public void LeaderBoard() {
		ButtonPressedSound.instance.PlayButtonSound();
        GameManager.Instance.ShowLeaderboardUI();
    }

	public void ShoppingPage() {
		ButtonPressedSound.instance.PlayButtonSound();
        SceneManager.LoadScene("Purchase Screen");
    }

	public void MuteSFX() {
		music.ToggleSFX();
		music.PauseSFX();
	}
}
