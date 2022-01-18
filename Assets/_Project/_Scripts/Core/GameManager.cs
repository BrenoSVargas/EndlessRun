using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _deadChannelEvent = default;
    [SerializeField] private VoidEventChannelSO _gameOverChannelEvent = default;

    private void DeadPlayer()
    {
        StateMachineController.Instance.ChangeTo<GameOverState>();
        _gameOverChannelEvent.RaiseEvent();
    }

    private void EnableEvents()
    {
        _deadChannelEvent.OnEventRaised += DeadPlayer;
    }

    private void DisableEvents()
    {
        _deadChannelEvent.OnEventRaised -= DeadPlayer;

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
