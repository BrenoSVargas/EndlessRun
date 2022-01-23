using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _sFXAudio;
    [SerializeField] private BoolEventChannelSO _onOffAudio = default;

    private bool isAudioEnable = true;
    private AudioSource _audioSource;

    public void Initialize(AudioClip sFXAudio, BoolEventChannelSO onOffAudio)
    {
        _sFXAudio = sFXAudio;
        _onOffAudio = onOffAudio;
    }

    private void Awake()
    {
        SearchAndSetComponents();
    }

    private void SearchAndSetComponents()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isAudioEnable = AudioManager.AudioEnabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckAndStartEffect();
    }

    private void CheckAndStartEffect()
    {
        if (_audioSource == null || isAudioEnable == false)
        {
            return;
        }
        _audioSource.clip = _sFXAudio;
        _audioSource.Play();

    }

    private void UIManager_OnOffAudio(bool value)
    {
        isAudioEnable = value;
    }

    private void EnableEvents()
    {
        _onOffAudio.OnEventRaised += UIManager_OnOffAudio;
    }
    private void DisableEvents()
    {
        _onOffAudio.OnEventRaised -= UIManager_OnOffAudio;
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
