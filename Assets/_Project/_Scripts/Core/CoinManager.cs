using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour, ISaveable
{
    [SerializeField] private IntEventChannelSO _coinsCounterEvent = default;
    [SerializeField] private IntEventChannelSO _coinsChangedEvent = default;
    [SerializeField] private VoidEventChannelSO _initEvent = default;
    private int _coinCounter;

    public void Initialize(IntEventChannelSO coinsCounter, IntEventChannelSO coinsChanged, VoidEventChannelSO initEvent)
    {
        _coinsCounterEvent = coinsCounter;
        _coinsChangedEvent = coinsChanged;
        _initEvent = initEvent;
    }
    private void Init()
    {
        _coinsChangedEvent.OnEventRaised(_coinCounter);

    }

    private void EventManager_UpdateCoins(int coins)
    {
        _coinCounter += coins;
        _coinsChangedEvent.OnEventRaised(_coinCounter);
    }

    private void EnableEvents()
    {
        _coinsCounterEvent.OnEventRaised += EventManager_UpdateCoins;
        _initEvent.OnEventRaised += Init;
    }

    private void DisableEvents()
    {
        _coinsCounterEvent.OnEventRaised -= EventManager_UpdateCoins;
        _initEvent.OnEventRaised -= Init;

    }

    private void OnEnable()
    {
        EnableEvents();
    }
    private void OnDisable()
    {
        DisableEvents();
    }

    public object CaptureData()
    {
        return _coinCounter;
    }

    public void RestoreData(object state)
    {
        _coinCounter = (int)state;
    }
}
