using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour {

	static DontDestroyMusic instance = null;

	void Awake () {
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		GetComponent<AudioSource>().ignoreListenerPause = true;
		PauseSFX();
	}

	public void ToggleMusic() {
		if (PlayerPrefs.GetInt("Muted") == 0) {
			PlayerPrefs.SetInt("Muted", 1);
		} else {
			PlayerPrefs.SetInt("Muted", 0);
		}
	}

	public void ToggleSFX() {
		if (PlayerPrefs.GetInt("SFX") == 0) {
			PlayerPrefs.SetInt("SFX", 1);
		} else {
			PlayerPrefs.SetInt("SFX", 0);
		}
	}

	public void PauseSFX () {
		if (PlayerPrefs.GetInt("SFX") == 0) {
			AudioListener.pause = false;
		} else {
			AudioListener.pause = true;
		}
	}
}
