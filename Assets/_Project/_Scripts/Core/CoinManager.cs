using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager _instance;
    public static CoinManager Instance { get { return _instance; } }

    private int _coinCounter;

    public Action<int> OnCoinsCounterUpdate;
    public Action<int> OnCoinsChangedValue;


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        OnCoinsCounterUpdate += CoinsCounter;
    }

    private void CoinsCounter(int coins)
    {
        _coinCounter += coins;        
        OnCoinsChangedValue?.Invoke(_coinCounter);
    }
}
