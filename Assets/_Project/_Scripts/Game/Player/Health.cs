using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _isHealthSoldOutChannelEvent = default;

    public void Initialize(VoidEventChannelSO isHealthSoldOutChannelEvent)
    {
        _isHealthSoldOutChannelEvent = isHealthSoldOutChannelEvent;
    }
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obs = other.gameObject.GetComponent<Obstacle>();
        if (!obs)
        {
            return;
        }
        HealthSoldOut();
    }

    private void HealthSoldOut()
    {
        _isHealthSoldOutChannelEvent.RaiseEvent();
    }
}
