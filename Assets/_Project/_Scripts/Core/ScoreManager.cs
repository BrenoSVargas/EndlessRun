using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, ISaveable
{
    private int _scoreCounter;
    private int _bestScore;
    private float _scoreHandleCounter;

    public float SmoothScoreCounter = 1f;

    [SerializeField] private VoidEventChannelSO _onDeadChannelEvent = default;
    [SerializeField] private VoidEventChannelSO _onScoreUpdateEveryFrameEvent = default;
    [SerializeField] private IntEventChannelSO _onScoreChannelEvent = default;
    [SerializeField] private IntEventChannelSO _onIncreasedScoreChannelEvent = default;
    [SerializeField] private IntEventChannelSO _onBestScoreChannelEvent = default;



    public void Initialize()
    {
        SmoothScoreCounter = 1f;
        Awake();
    }

    private void Awake()
    {
        InitGame();
    }

    public void ScorerUpdateEveryFrame()
    {
        _scoreHandleCounter += StateMachineController.Instance.SpeedGame * Time.deltaTime * SmoothScoreCounter;
        _scoreCounter = Mathf.RoundToInt(_scoreHandleCounter);

        _onIncreasedScoreChannelEvent.RaiseEvent(_scoreCounter);
    }

    public void InitGame()
    {
        _scoreCounter = 0;
    }

    public object CaptureData()
    {
        return _bestScore;
    }

    public void RestoreData(object state)
    {
        _bestScore = (int)state;
    }

    private void ScoreManager_CheckIsBestScore()
    {
        if (_scoreCounter > _bestScore)
        {
            _bestScore = _scoreCounter;
        }

        _onScoreChannelEvent.RaiseEvent(_scoreCounter);
        _onBestScoreChannelEvent.RaiseEvent(_bestScore);
    }

    private void EnableEvents()
    {
        _onDeadChannelEvent.OnEventRaised += ScoreManager_CheckIsBestScore;
        _onScoreUpdateEveryFrameEvent.OnEventRaised += ScorerUpdateEveryFrame;
    }

    private void DisableEvents()
    {
        _onDeadChannelEvent.OnEventRaised -= ScoreManager_CheckIsBestScore;
        _onScoreUpdateEveryFrameEvent.OnEventRaised -= ScorerUpdateEveryFrame;


    }

    private void OnEnable()
    {
        EnableEvents();
    }

    private void OnDisable()
    {
        DisableEvents();
    }

}
