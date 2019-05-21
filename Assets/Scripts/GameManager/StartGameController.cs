using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    [SerializeField]
    private GameObject quitPanel;

    [SerializeField]
    private GameObject itemsGameObject;

    void Awake()
    {
        quitPanel.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            quitPanel.SetActive(true);
            itemsGameObject.SetActive(false);
        }
    }

    public void StartGameScene()
    {
        ButtonPressedSound.instance.PlayButtonSound();
        SceneManager.LoadScene("Select Type");
    }

    public void CartPage() {
        ButtonPressedSound.instance.PlayButtonSound();
        SceneManager.LoadScene("Purchase Screen");
    }

    public void LeaderBoard() {
        ButtonPressedSound.instance.PlayButtonSound();
        GameManager.Instance.ShowLeaderboardUI();
    }

    public void Settings() {
		ButtonPressedSound.instance.PlayButtonSound();
        SceneManager.LoadScene("Settings");
    }

    public void HideQuitPanel() {
        quitPanel.SetActive(false);
        itemsGameObject.SetActive(true);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void RemoveLater()
    {
        PlayerPrefs.DeleteAll();
    }
}
