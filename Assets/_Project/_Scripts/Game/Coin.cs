using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int coinValue = 1;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void Effect()
    {
        Instantiate(vFXToInstante, transform.position, Quaternion.identity);
        CoinManager.Instance.OnCoinsCounterUpdate?.Invoke(coinValue);
        
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
