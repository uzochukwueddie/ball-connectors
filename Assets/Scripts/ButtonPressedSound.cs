using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressedSound : MonoBehaviour {

	public static ButtonPressedSound instance;

    public AudioSource[] audioSources { get; private set; }

    // Use this for initialization
    void Start () {
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}

		audioSources = GetComponents<AudioSource>();
	}

	public void PlayButtonSound() {
		audioSources[0].Play();		
	}

	public void StopButtonSound() {
		audioSources[0].Stop();		
	}

	public void PlayDrawSound() {		
		InvokeRepeating("DrawSound", 0.01f, 0.2f);
	}

	public void StopDrawSound() {
		audioSources[1].Stop();
		CancelInvoke("DrawSound");
	}

	void DrawSound() {
		audioSources[1].Play();	
	}
}
