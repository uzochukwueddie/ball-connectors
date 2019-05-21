using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour {

	public static SoundScript instance;

	private DontDestroyMusic music;

	public Button musicToggleButton;
	public Sprite unMute;
	public Sprite mute;

	private GameObject bgMusic;

	void Start () {
		if (instance == null) {
			instance = this;
		} 
		bgMusic = GameObject.Find("BackgroundMusic");
		bgMusic.GetComponent<AudioSource> ().Play ();
		music = GameObject.FindObjectOfType<DontDestroyMusic>();
		UpdateIcon();
	}
	
	void UpdateIcon () {
		if (PlayerPrefs.GetInt("Muted") == 0) {
			bgMusic.GetComponent<AudioSource>().volume = 0f;
			musicToggleButton.GetComponent<Image>().sprite =  mute;
			PlayerPrefs.Save ();
		} else {
			musicToggleButton.GetComponent<Image>().sprite =unMute ;
			bgMusic.GetComponent<AudioSource>().volume =  0.45f;
			PlayerPrefs.Save ();
		}
	}

	public void PauseMusic() {
		music.ToggleMusic();
		UpdateIcon();
	}
}
