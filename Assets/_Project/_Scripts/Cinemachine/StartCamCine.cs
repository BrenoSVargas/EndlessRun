using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartCamCine : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _onGameIsStarted = default;
    [SerializeField] private int _priority = 0;

    public void Initialize(VoidEventChannelSO gameStartedEvent, int newPriority)
    {
        _onGameIsStarted = gameStartedEvent;
        _priority = newPriority;
    }

    private void NextCinemachine()
    {
        GetComponent<CinemachineVirtualCamera>().Priority = _priority;
    }

    private void OnEnable()
    {
        _onGameIsStarted.OnEventRaised += NextCinemachine;
    }

    private void OnDisable()
    {
        _onGameIsStarted.OnEventRaised -= NextCinemachine;
    }
}
