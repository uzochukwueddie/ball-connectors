using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;

    private Text scoreText;

    [SerializeField]
    private Text gameOverScoreText;

    [SerializeField]
    private Text levelCompleteScoreText;

    private Text hintText;

    private int score;

    [HideInInspector]
    public int hint;

    private int hintScore;

    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject gameComplete;

    [SerializeField]
    private GameObject topPanel;

    [SerializeField]
    private GameObject mazeSolution;

    [SerializeField]
    private GameObject lineCamera;

    private Button hintButton;

    private Scene currentScene;

    [HideInInspector]
    public bool gameIsOver;

    private int intValue = 1;

    private int sceneIndex, levelPassed;

    private int circleLevelPassd, circleSceneIndex;

    private int hexLevelPassed, hexSceneIndex;

    [HideInInspector]
    public bool hasCollided = false;

    private string showingSolution;

    [SerializeField]
    private GameObject maze;

    [SerializeField]
    private GameObject moreHintsPanel;

    [SerializeField]
    private GameObject quitPanel;

    private string noMoreHint;

    [HideInInspector]
    public bool gameIsComplete = false;

    [HideInInspector]
    public bool gameHasStarted = false;

    [HideInInspector]
    public bool gameCompleted = false;

    private int countTime = 4;

    private Text counterText;

    private Animator anim;

    // private Image hintImage;
    // public Sprite hintSpriteRed, hintSpriteYellow;

    void Awake()
    {
        MakeInstance();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        hintText = GameObject.Find("Hint").GetComponent<Text>();
        hintButton = GameObject.FindGameObjectWithTag("Hint").GetComponent<Button>();
        // hintImage = GameObject.FindGameObjectWithTag("Hint").GetComponent<Image>();
        counterText = GameObject.Find("count").GetComponent<Text>();
        hasCollided = true;
        gameOver.SetActive(false);
        gameComplete.SetActive(false);
        topPanel.SetActive(true);
        moreHintsPanel.SetActive(false);
        quitPanel.SetActive(false);
        currentScene = SceneManager.GetActiveScene();
        gameIsOver = false;
        score = PlayerPrefs.GetInt("playerScore");
        hintScore = PlayerPrefs.GetInt("hintValue");
        noMoreHint = PlayerPrefs.GetString("noMoreHint");
        anim = GameObject.FindGameObjectWithTag("Maze").GetComponent<Animator>();
        hintButton.interactable = false;

        if ((hintScore == 0 && noMoreHint == "") || (hintScore > 0 && noMoreHint == "")) {
            hint = 30;
        }

        if (hintScore > 0 && hintScore < 30) {
            hint = hintScore;
        } else if (hintScore > 30) {
            hint = hintScore;
        }

        hintText.text = hint.ToString();

        sceneIndex = currentScene.buildIndex - 4;
        circleSceneIndex = currentScene.buildIndex - 14;
        hexSceneIndex = currentScene.buildIndex - 24;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        circleLevelPassd = PlayerPrefs.GetInt("CircleLevelPassed");
        hexLevelPassed = PlayerPrefs.GetInt("HexagonLevelPassed");
        showingSolution = PlayerPrefs.GetString("showSolution");
    }

    void Start() {
        InvokeRepeating("CountDown", 0.0f, 1.0f);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && gameHasStarted == true) {
            quitPanel.SetActive(true);
            maze.SetActive(false);
            gameOver.SetActive(false);
            topPanel.SetActive(false);
            lineCamera.SetActive(false);
            moreHintsPanel.SetActive(false);
        }

        if (counterText.text == "0") {
            counterText.text = "Start";
        }

        // if (hint <= 0) {
        //     hintImage.sprite = hintSpriteRed;
        // }
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoadedEvent; //subscribe to the event
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoadedEvent;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("playerScore", score);
    }

    void OnSceneLoadedEvent(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == currentScene.name)
        {
            if (GameManager.Instance.gameStartedFromMainMenu)
            {
                GameManager.Instance.gameStartedFromMainMenu = false;
                score = 0;
                hint = PlayerPrefs.GetInt("hintValue");
            }
            else if (GameManager.Instance.gameRestarted)
            {
                GameManager.Instance.gameRestarted = false;
                score = GameManager.Instance.score;
                if (showingSolution == "yes") {
                    mazeSolution.SetActive(true);
                }
            }
            scoreText.text = score.ToString();
            hintText.text = hint.ToString();
        }
    }

    public void IncrementScore()
    {
        score += 10;
        scoreText.text = score.ToString();
    }

    public int CheckCircles()
    {
        return intValue++;
    }

    public void GameOver()
    {
        StartCoroutine(ShowGameOver());
    }

    public void RestartGame()
    {
        StartCoroutine(GameReload(currentScene.buildIndex));
    }

    public void GameCompletePanel()
    {
        if (currentScene.buildIndex >= 5 && currentScene.buildIndex <= 14) {
            if (levelPassed < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            }
            StartCoroutine(ShowLevelComplete());
        }

        if (currentScene.buildIndex >= 15 && currentScene.buildIndex <= 24) {
            if (circleLevelPassd < circleSceneIndex) {
                PlayerPrefs.SetInt("CircleLevelPassed", circleSceneIndex);
            }
            StartCoroutine(ShowLevelComplete());
        }

        if (currentScene.buildIndex >= 25 && currentScene.buildIndex <= 34) {
            if (hexLevelPassed < hexSceneIndex) {
                PlayerPrefs.SetInt("HexagonLevelPassed", hexSceneIndex);
            }
            StartCoroutine(ShowLevelComplete());
        }

    }

    public void LoadNextLevel()
    {
        ButtonPressedSound.instance.PlayButtonSound();
        GameManager.Instance.score = score;
        GameManager.Instance.hint = hint;
        PlayerPrefs.DeleteKey("showSolution");
        StartCoroutine(NextLevel());
    }

    public void LoadNextCategory(int index) {
        ButtonPressedSound.instance.PlayButtonSound();
        GameManager.Instance.score = score;
        GameManager.Instance.hint = hint;
        PlayerPrefs.DeleteKey("showSolution");
        StartCoroutine(NextCategory(index));
    }

    public void HomeButton()
    {
        ButtonPressedSound.instance.PlayButtonSound();
        PlayerPrefs.SetInt("hintValue", hint);
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void ShowSolution() {
        ButtonPressedSound.instance.PlayButtonSound();
        hint -= 10;
        gameIsOver = false;
        if (hint > 0) {
            PlayerPrefs.SetInt("hintValue", hint);
            PlayerPrefs.SetString("showSolution", "yes");
            mazeSolution.SetActive(true);
            hintText.text = hint.ToString();
            hintButton.interactable = false;
            PlayerPrefs.SetString("noMoreHint", "false");
        } else if(hint == 0) {
            hintText.text = hint.ToString();
            mazeSolution.SetActive(true);
            PlayerPrefs.SetString("noMoreHint", "true");
        } 

        if (hint < 0) {
            moreHintsPanel.SetActive(true);
            mazeSolution.SetActive(false);
            maze.SetActive(false);
            quitPanel.SetActive(false);
            gameOver.SetActive(false);
            topPanel.SetActive(false);
            lineCamera.SetActive(false);
        } 
    }

    public void HideMoreHintsPanel() {
        ButtonPressedSound.instance.PlayButtonSound();
        maze.SetActive(true);
        topPanel.SetActive(true);
        lineCamera.SetActive(true);
        moreHintsPanel.SetActive(false);
        gameOver.SetActive(false);
        anim.SetTrigger("Slide");
        
    }

    public void HideQuitPanel() {
        ButtonPressedSound.instance.PlayButtonSound();
        quitPanel.SetActive(false);
        maze.SetActive(true);
        topPanel.SetActive(true);
        gameOver.SetActive(false);
        lineCamera.SetActive(true);
        anim.SetTrigger("Slide");
    }

    // Remove this part
    public void ShowQuitPanel() {
        quitPanel.SetActive(true);
        maze.SetActive(false);
        gameOver.SetActive(false);
        topPanel.SetActive(false);
        lineCamera.SetActive(false);
    }

    public void QuitGame(){
        ButtonPressedSound.instance.PlayButtonSound();
        Application.Quit();
    }

    // public void AddMoreHint(int value) {
    //     hint += value;
    //     hintImage.sprite = hintSpriteYellow;
    //     if (hintText != null) {
    //         hintText.text = hint.ToString();
    //         PlayerPrefs.SetInt("hintValue", hint);
    //     } else {
    //         PlayerPrefs.SetInt("hintValue", hint);
    //     }
    // }

    void CountDown() {
        if (countTime == 0) {
            CancelInvoke("CountDown");
        } else {
            countTime -= 1;
            counterText.text = countTime.ToString();
        }

        if (counterText.text == "Start") {
            counterText.enabled = false;
            anim.SetTrigger("Slide");
            gameHasStarted = true;
            hintButton.interactable = true;
        }
    }

    IEnumerator GameReload(int sceneName)
    {
        PlayerPrefs.SetInt("hintValue", hint);
        gameIsOver = false;
        GameManager.Instance.gameRestarted = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
        ButtonPressedSound.instance.StopDrawSound();
    }

    IEnumerator WaitBeforeReplay()
    {
        yield return new WaitForSeconds(1f);
        gameOver.SetActive(false);
        topPanel.SetActive(false);
        gameComplete.SetActive(false);
        SceneManager.LoadScene("Main Menu Scene");
    }

    IEnumerator NextLevel()
    {
        gameIsOver = false;
        GameManager.Instance.gameRestarted = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    IEnumerator NextCategory(int index)
    {
        gameIsOver = false;
        GameManager.Instance.gameRestarted = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(index);
    }

    IEnumerator ShowLevelComplete()
    {
        yield return new WaitForSeconds(1f);
        gameComplete.SetActive(true);
        gameOver.SetActive(false);
        topPanel.SetActive(false);
        levelCompleteScoreText.text = score.ToString();
        // GameManager.Instance.AddScoreToLeaderboard(GPGSIds.leaderboard_players_score, score);
        gameIsOver = true;
        gameIsComplete = true;
        mazeSolution.SetActive(false);
        maze.SetActive(false);
        lineCamera.SetActive(false);
        ButtonPressedSound.instance.StopDrawSound();
    }

    IEnumerator ShowGameOver() {
        yield return new WaitForSeconds(0.8f);
        gameIsOver = true;
        gameOver.SetActive(true);
        maze.SetActive(false);
        topPanel.SetActive(false);
        lineCamera.SetActive(false);
        ButtonPressedSound.instance.StopDrawSound();
        string sceneName = currentScene.name;
        if (sceneName == "Level01")
        {
            gameOverScoreText.text = "0";
        }
        else
        {
            gameOverScoreText.text = score.ToString();
        }
    }
}
