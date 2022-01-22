using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int coinValue = 1;

    [SerializeField] private IntEventChannelSO _coinsCounterEvent = default;
    [SerializeField] private PosEventChannelSO _coinEffcetsEvent = default;

    public void Initialize(IntEventChannelSO coinsCounterEvent, PosEventChannelSO coinEffectsEvent)
    {
        _coinsCounterEvent = coinsCounterEvent;
        _coinEffcetsEvent = coinEffectsEvent;
    }

    private void Start()
    {
        SearchAndSetComponents();
    }

    private void SearchAndSetComponents()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void Effect()
    {

        _coinsCounterEvent.RaiseEvent(coinValue);
        _coinEffcetsEvent.RaiseEvent(transform.position);

        if (meshRenderer) meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
            Effect();
    }

    private void OnEnable()
    {
        if (meshRenderer)
        { meshRenderer.enabled = true; }
    }
}
