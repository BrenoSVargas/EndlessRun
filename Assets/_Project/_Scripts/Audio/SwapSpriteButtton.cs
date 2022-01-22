using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapSpriteButtton : MonoBehaviour
{
    private enum StateButton
    {
        Off,
        On,
    }
    private StateButton _current = StateButton.On;

    private Image _image;

    [SerializeField] private Sprite _onAudioSprite, _offAudioSprite;

    [SerializeField] private BoolEventChannelSO _onOffAudio = default;

    public void Initialize(BoolEventChannelSO onOffAudio)
    {
        _onOffAudio = onOffAudio;
    }

    private void Awake()
    {
        SearchAndComponents();
    }

    private void SearchAndComponents()
    {
        _image = GetComponent<Image>();
    }


    private void UIManager_AudioOnOff(bool value)
    {
        if (!value.Equals(_current))
        {
            int x = Convert.ToInt32(value);
            _current = (StateButton)x;
            SwapImgButton();
        }
    }

    private void SwapImgButton()
    {

        if (_current == StateButton.On)
        {
            _image.sprite = _onAudioSprite;
        }
        else
        {
            _image.sprite = _offAudioSprite;

        }
    }

    private void EnableEvents()
    {
        _onOffAudio.OnEventRaised += UIManager_AudioOnOff;

    }

    private void DisableEvents()
    {
        _onOffAudio.OnEventRaised -= UIManager_AudioOnOff;

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
