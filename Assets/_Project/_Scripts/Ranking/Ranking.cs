using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour, ISaveable
{
    [SerializeField] private IntEventChannelSO _bestScoreChannelEvent = default;

    private int _bestScore;

    public void Initialize(IntEventChannelSO bestScoreChannel)
    {
        _bestScoreChannelEvent = bestScoreChannel;
    }
    public object CaptureData()
    {
        return _bestScore;
    }

    public void RestoreData(object state)
    {
        int data = (int)state;
        _bestScore = data;
    }
    private void Ranking_BestScore(int value)
    {
        _bestScore = value;
    }

    private void EnableEvents()
    {
        _bestScoreChannelEvent.OnEventRaised += Ranking_BestScore;
    }

    private void DisableEvents()
    {
        _bestScoreChannelEvent.OnEventRaised -= Ranking_BestScore;

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
