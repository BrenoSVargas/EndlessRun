using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinVFXGenerator : PoolManager
{
    [SerializeField] private VoidEventChannelSO _initGameEvent = default;
    [SerializeField] private PosEventChannelSO _coinEffctesEvent = default;

    public void Initialize(VoidEventChannelSO initGame, PosEventChannelSO coinEffects)
    {
        _initGameEvent = initGame;
        _coinEffctesEvent = coinEffects;
    }
    protected override void InitGame()
    {
        base.InitGame();

    }

    private void GenerateCoinEffect(Vector3 pos)
    {
        GameObject effectGO = GetItem();

        if (!effectGO)
        {
            return;
        }
        effectGO.SetActive(true);
        effectGO.transform.position = pos;

    }



    private void EnableEvents()
    {
        _initGameEvent.OnEventRaised += InitGame;
        _coinEffctesEvent.OnEventRaised += GenerateCoinEffect;

    }

    private void DisableEvents()
    {
        _initGameEvent.OnEventRaised -= InitGame;
        _coinEffctesEvent.OnEventRaised -= GenerateCoinEffect;

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
