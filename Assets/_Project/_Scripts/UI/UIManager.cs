using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public sealed class UIManager : MonoBehaviour
{
    private Button _pauseButton, _returnGameButton, _soundButton, _restartButton, _exitButton;
    private PanelPositioner _pausePanel;

    private TMP_Text _scoreText, _coinsText;

    [SerializeField] private IntEventChannelSO _coinsChangedEvent = default;

    public void Initialize()
    {
        Awake();
    }
    private void Awake()
    {
        SearchComponents();
        AddMethods();
    }

    private void Start()
    {
        ScoreManager.Instance.OnScoreUpdate += ScoreManager_UpdateScore;
        _coinsChangedEvent.OnEventRaised += EventManager_UpdateCoins;
    }


    private void SearchComponents()
    {
        //Search
        _pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        _returnGameButton = GameObject.Find("ReturnGameButton").GetComponent<Button>();
        _soundButton = GameObject.Find("SoundButton").GetComponent<Button>();
        _restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        _exitButton = GameObject.Find("ExitButton").GetComponent<Button>();

        _scoreText = GameObject.Find("ScoreCountText").GetComponent<TMP_Text>();
        _coinsText = GameObject.Find("CoinsCountText").GetComponent<TMP_Text>();

        _pausePanel = GameObject.Find("PausePanel").GetComponent<PanelPositioner>();
    }
    private void AddMethods()
    {
        //Methods
        _pauseButton.onClick.AddListener(PauseGame);
        _returnGameButton.onClick.AddListener(ReturnGame);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void PauseGame()
    {
        _pausePanel.MoveTo(PanelPosition.PositionType.Show);
        _pauseButton.interactable = false;
        StateMachineController.Instance.ChangeTo<PauseState>();
    }

    private void ReturnGame()
    {
        _pausePanel.MoveTo(PanelPosition.PositionType.Hide);
        _pauseButton.interactable = true;
        StateMachineController.Instance.ChangeTo<InGameState>();
    }

    private void ExitGame()
    {
        StateMachineController.Instance.ChangeTo<MainMenuState>();
    }

    private void ScoreManager_UpdateScore(int score)
    {
        _scoreText.text = score.ToString("D6");
    }

    private void EventManager_UpdateCoins(int coin)
    {
        _coinsText.text = coin.ToString();
    }


}
