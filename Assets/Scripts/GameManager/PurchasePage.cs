using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PurchasePage : MonoBehaviour {

	public void HomePage() {
		ButtonPressedSound.instance.PlayButtonSound();
		SceneManager.LoadScene("Main Menu Scene");
	}
	
	public void LeaderBoard() {
		ButtonPressedSound.instance.PlayButtonSound();
        GameManager.Instance.ShowLeaderboardUI();
    }

	public void Settings() {
		ButtonPressedSound.instance.PlayButtonSound();
        SceneManager.LoadScene("Settings");
    }
}
