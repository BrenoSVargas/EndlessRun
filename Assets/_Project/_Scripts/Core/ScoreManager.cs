using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }
    private float _speedGame;
    public float SpeedGame { get { return _speedGame; } }
    private int _scoreCounter;
    private float _scoreHandleCounter;

    public Action<int> OnScoreUpdate;

    public float StartSpeedGame = 0.2f;
    public float SmoothScoreCounter = 20f;
    public float TimeMultiplayerSpeed = 1.2f;

    public void Initialize()
    {
        SmoothScoreCounter = 20f;
        StartSpeedGame = 0.2f;
        TimeMultiplayerSpeed = 1.2f;
        Awake();
    }

    private void Awake()
    {
        _instance = this;
        InitGame();
    }

    public void ScorerUpdateEveryFrame()
    {
        _scoreHandleCounter += _speedGame * Time.deltaTime * SmoothScoreCounter;
        _scoreCounter = Mathf.RoundToInt(_scoreHandleCounter);

        OnScoreUpdate?.Invoke(_scoreCounter);
    }

    public void UpdateSpeedGame()
    {
        _speedGame *= TimeMultiplayerSpeed;
    }

    public void InitGame()
    {
        _scoreCounter = 0;
        _speedGame = StartSpeedGame;
    }
}
