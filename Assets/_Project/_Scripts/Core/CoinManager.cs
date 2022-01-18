using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int _coinCounter;
    [SerializeField] private IntEventChannelSO _coinsCounterEvent = default;
    [SerializeField] private IntEventChannelSO _coinsChangedEvent = default;

    private void EventManager_UpdateCoins(int coins)
    {
        _coinCounter += coins;
        _coinsChangedEvent.OnEventRaised(_coinCounter);
    }

    private void EnableEvents()
    {
        _coinsCounterEvent.OnEventRaised += EventManager_UpdateCoins;
    }

    private void DisableEvents()
    {
        _coinsCounterEvent.OnEventRaised -= EventManager_UpdateCoins;
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
