using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundController : MonoBehaviour
{
    private bool isAudioEnable = true;
    [SerializeField] private AudioClip _sFXAudio;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
}
