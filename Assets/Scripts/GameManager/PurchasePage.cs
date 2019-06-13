using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PurchasePage : MonoBehaviour {

	public enum ItemType {
		HINT50,
		HINT200,
		HINT400,
		NOADS
	};

	public ItemType itemType;

	private Text pricetext;

	// private string defaultText;

	void Start() {
		// defaultText = pricetext.text;
	}

	// public void BuyHints(int hint) {
	// 	switch(itemType) {
	// 		case ItemType.HINT50:
	// 			IAPManager.Instance.BuyHint50();
	// 			break;
	// 		case ItemType.HINT200:
	// 			IAPManager.Instance.BuyHint200();
	// 			break;
	// 		case ItemType.HINT400:
	// 			IAPManager.Instance.BuyHint400();
	// 			break;
	// 		// case ItemType.NOADS:
	// 		// 	IAPManager.Instance.RemoveADS();
	// 		// 	break;
	// 	}
	// }

	public void Buy50Hints() {
		// IAPManager.Instance.BuyHint50();
	}

	public void Buy200Hints() {
		// IAPManager.Instance.BuyHint200();
	}

	public void Buy400Hints() {
		// IAPManager.Instance.BuyHint400();
	}

	public void RemoveADS() {
		// IAPManager.Instance.RemoveADS();
	}

	public void HomePage() {
		ButtonPressedSound.instance.PlayButtonSound();
		SceneManager.LoadScene("Main Menu Scene");
	}
	
	public void LeaderBoard() {
		ButtonPressedSound.instance.PlayButtonSound();
        // GameManager.Instance.ShowLeaderboardUI();
    }

	public void Settings() {
		ButtonPressedSound.instance.PlayButtonSound();
        SceneManager.LoadScene("Settings");
    }
}
