using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int coinValue = 1;

    protected override void Effect()
    {
        Instantiate(vFXToInstante, transform.position, Quaternion.identity);
        CoinManager.Instance.OnCoinsCounterUpdate?.Invoke(coinValue);
        Destroy(this.gameObject, 0.01f);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
            Effect();
    }
}
