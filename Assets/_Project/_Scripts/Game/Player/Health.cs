using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _isDeadChannelEvent = default;

    public void Initialize(VoidEventChannelSO isDeadChannel)
    {
        _isDeadChannelEvent = isDeadChannel;
    }
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obs = other.gameObject.GetComponent<Obstacle>();
        if (!obs) return;
        PlayerIsDead();
    }

    private void PlayerIsDead()
    {
        _isDeadChannelEvent.RaiseEvent();
    }
}
