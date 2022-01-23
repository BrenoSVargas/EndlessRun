using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _isHealthSoldOutChannelEvent = default;
    [SerializeField] private VoidEventChannelSO _gameOverChannelEvent = default;

    public void Initialize(VoidEventChannelSO isHealthSoldOutChannelEvent, VoidEventChannelSO gameOverChannelEvent)
    {
        _isHealthSoldOutChannelEvent = isHealthSoldOutChannelEvent;
        _gameOverChannelEvent = gameOverChannelEvent;
    }
    private void DeadPlayer()
    {
        StateMachineController.Instance.ChangeTo<GameOverState>();
        _gameOverChannelEvent.RaiseEvent();
    }

    private void EnableEvents()
    {
        _isHealthSoldOutChannelEvent.OnEventRaised += DeadPlayer;
    }

    private void DisableEvents()
    {
        _isHealthSoldOutChannelEvent.OnEventRaised -= DeadPlayer;

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
