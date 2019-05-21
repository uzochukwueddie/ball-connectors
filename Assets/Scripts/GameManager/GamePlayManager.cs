using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{

    public static GamePlayManager Instance { get; private set; }

    [HideInInspector]
    public int score;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestarted;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
