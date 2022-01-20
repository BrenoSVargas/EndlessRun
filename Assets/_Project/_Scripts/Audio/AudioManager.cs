using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AudioManager : MonoBehaviour
{
    private bool isAudioEnable = true;
    [SerializeField] private AudioClip _musicAudio;
    private AudioSource _audioSource;

    [SerializeField] private VoidEventChannelSO _onInitGameChannelEvent = default;

    public void Initialize(AudioClip music, VoidEventChannelSO initEvent)
    {
        _musicAudio = music;
        _onInitGameChannelEvent = initEvent;

    }
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnPlayAudioBackground()
    {
        if (_audioSource.clip == null)
        {
            _audioSource.clip = _musicAudio;
        }

        _audioSource.Play();
    }


    private void EnableEvents()
    {
        _onInitGameChannelEvent.OnEventRaised += OnPlayAudioBackground;
    }
    private void DisableEvents()
    {
        _onInitGameChannelEvent.OnEventRaised -= OnPlayAudioBackground;
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
