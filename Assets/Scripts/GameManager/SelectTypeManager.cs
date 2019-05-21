using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTypeManager : MonoBehaviour
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

    public void RectangleScene()
    {
        ButtonPressedSound.instance.PlayButtonSound();
        PlayerPrefs.SetInt("BgNumber", 0);
        SceneManager.LoadScene("Rectangle");
    }

    public void CircleScene()
    {
        ButtonPressedSound.instance.PlayButtonSound();
        PlayerPrefs.SetInt("BgNumber", 1);
        SceneManager.LoadScene("Circle");
    }

    public void HexagonScene()
    {
        ButtonPressedSound.instance.PlayButtonSound();
        PlayerPrefs.SetInt("BgNumber", 2);
        SceneManager.LoadScene("Hexagon");
    }

    public void HomeButton () {
        ButtonPressedSound.instance.PlayButtonSound();
        StartCoroutine(WaitBeforeReplay());
    }

    public void HideQuitPanel() {
        quitPanel.SetActive(false);
        itemsGameObject.SetActive(true);
    }

    public void QuitGame(){
        Application.Quit();
    }

    IEnumerator WaitBeforeReplay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu Scene");
    }
}
