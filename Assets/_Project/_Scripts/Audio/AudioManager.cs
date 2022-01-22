using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AudioManager : MonoBehaviour
{
    private bool isAudioEnable = true;
    [SerializeField] private AudioClip _musicAudio;
    private AudioSource _audioSource;

    [SerializeField] private VoidEventChannelSO _onInitGameChannelEvent = default;
    [SerializeField] private BoolEventChannelSO _onOffAudio = default;

    public void Initialize(AudioClip music, VoidEventChannelSO initEvent, BoolEventChannelSO onOffAudio)
    {
        _musicAudio = music;
        _onInitGameChannelEvent = initEvent;
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

    private void OnPlayAudioBackground()
    {
        if (!isAudioEnable)
        {
            _audioSource.Stop();
            return;
        }
        if (_audioSource.clip == null)
        {
            _audioSource.clip = _musicAudio;
        }

        _audioSource.Play();
    }

    private void UIManager_OnOffAudio(bool value)
    {
        isAudioEnable = value;
        OnPlayAudioBackground();
    }


    private void EnableEvents()
    {
        _onInitGameChannelEvent.OnEventRaised += OnPlayAudioBackground;
        _onOffAudio.OnEventRaised += UIManager_OnOffAudio;
    }
    private void DisableEvents()
    {
        _onInitGameChannelEvent.OnEventRaised -= OnPlayAudioBackground;
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
