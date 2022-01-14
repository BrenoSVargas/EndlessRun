using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuManager : MonoBehaviour
{
    private Button _playGameButton, _rankingButton, _quitButton;

    public void Initialize()
    {
        Awake();
    }
    private void Awake()
    {
        SearchComponentsAndMethods();
    }

    private void SearchComponentsAndMethods()
    {
        //Search
        _playGameButton = GameObject.Find("PlayButton").GetComponent<Button>();
        _rankingButton = GameObject.Find("RankingButton").GetComponent<Button>();
        _quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        //Methods
        _playGameButton.onClick.AddListener(PlayGame);
        _rankingButton.onClick.AddListener(Ranking);
        _quitButton.onClick.AddListener(Quit);
    }

    public void PlayGame()
    {
        StateMachineController.Instance.ChangeTo<LoadState>();
    }

    public void Ranking()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
