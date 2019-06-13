using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollider : MonoBehaviour
{
    public static BallCollider instance;
    
    [HideInInspector]
    public int numberOfCircles = 0;

    private int val;

    private int levelPassed, circleLevelPassed;

    private int hexLevelPassed;

    private Scene currentScene;

    [HideInInspector]
    public bool levelCompleted = false;

    private ParticleSystem fireworks;

    public int timer;

    public bool stopLine;

    IEnumerator coroutine;


    void Awake() {
        MakeInstance();
    }

    void Start()
    {
        stopLine = false;
        fireworks = GameObject.FindGameObjectWithTag("Fireworks").GetComponent<ParticleSystem>();
        val = GameObject.FindGameObjectsWithTag("Ball").Length;

        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        circleLevelPassed = PlayerPrefs.GetInt("CircleLevelPassed");
        hexLevelPassed = PlayerPrefs.GetInt("HexagonLevelPassed");

        currentScene = SceneManager.GetActiveScene();

        coroutine = StartFireworks();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (numberOfCircles == val)
        {
            timer += 1;
            stopLine = true;
            StartCoroutine(coroutine);
            StartCoroutine(ShowLevelComplete());
        }

        if (timer > 2 && fireworks.isPlaying) {
			fireworks.Stop();
			StopCoroutine(coroutine);
			timer = 0;
		}

        if (currentScene.buildIndex >= 5 && currentScene.buildIndex <= 14) {
            if (levelPassed >= currentScene.buildIndex - 4)
            {
                levelCompleted = true;
            } 
            else
            {
                levelCompleted = false;
            } 
        }

        if (currentScene.buildIndex >= 15 && currentScene.buildIndex <= 24) {
            if (circleLevelPassed >= currentScene.buildIndex - 14)
            {
                levelCompleted = true;
            }
            else
            {
                levelCompleted = false;
            } 
        }

        if (currentScene.buildIndex >= 25 && currentScene.buildIndex <= 34) {
            if (hexLevelPassed >= currentScene.buildIndex - 24)
            {
                levelCompleted = true;
            }
            else
            {
                levelCompleted = false;
            } 
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (levelCompleted == false)
            {
                GamePlay.instance.IncrementScore();
                PlayFireworksAudio();
            }
            PlayFireworksAudio();

            foreach (ContactPoint2D missileHit in other.contacts)
            {
                Vector2 hitPoint = missileHit.point;
                fireworks.transform.position = new Vector2(hitPoint.x, hitPoint.y);
                fireworks.Emit(1000);
            }
            numberOfCircles++;
        }
    }

    public void PlayFireworksAudio() {
        GetComponent<AudioSource>().Play();
    }

    public void StopFireworksAudio() {
        GetComponent<AudioSource>().Stop();
    }

    IEnumerator StartFireworks() {
		yield return new WaitForSeconds(0.01f);
		// GetComponent<AudioSource>().Play();
        PlayFireworksAudio();
        fireworks.Emit(1000);
	}

    IEnumerator ShowLevelComplete() {
		yield return new WaitForSeconds(0.5f);
		GamePlay.instance.GameCompletePanel();
	}
}
