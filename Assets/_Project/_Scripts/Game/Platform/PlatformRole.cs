using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRole : MonoBehaviour
{
    [SerializeField] private int _randomChance = 3;
    [SerializeField] List<CoinRow> _roles = new List<CoinRow>();

    public void Initialize(int randomChance)
    {
        _randomChance = randomChance;
        Awake();
    }
    private void Awake()
    {
        _roles.AddRange(GetComponentsInChildren<CoinRow>());
    }

    private void OnEnable()
    {
        foreach (CoinRow cr in _roles)
        {
            cr.gameObject.SetActive(IsActiveRandom());
        }

    }

    private bool IsActiveRandom() => UnityEngine.Random.Range(1, 11) <= _randomChance;
}
