using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class VFXController : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _eventoToActiveChannel = default;
    private GameObject _vFXParent;

    public void Initialize(VoidEventChannelSO effectJumpChannel)
    {
        _eventoToActiveChannel = effectJumpChannel;
        Awake();
    }

    private void Awake()
    {
        SearchComponents();
    }

    private void SearchComponents()
    {
        _vFXParent = GetComponentInChildren<ParticleSystem>().gameObject;
    }

    private void EffectChannel_ShowEffect()
    {
        _vFXParent.SetActive(true);
    }
    private void EnableEvents()
    {
        _eventoToActiveChannel.OnEventRaised += EffectChannel_ShowEffect;

    }

    private void DisableEvents()
    {
        _eventoToActiveChannel.OnEventRaised -= EffectChannel_ShowEffect;
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

