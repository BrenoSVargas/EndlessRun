using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadState : State
{
    private List<AsyncOperation> _sceneLoading = new List<AsyncOperation>();

    public override void Enter()
    {
        machine.LoadingScreen.SetActive(true);

        StartCoroutine(LoadSequence());
    }
    public override void Exit()
    {
        machine.LoadingScreen.SetActive(false);

        Time.timeScale = 1f;
    }

    IEnumerator LoadSequence()
    {
        int percentLoad = 0;
        LoadUpdateUI(percentLoad);

        _sceneLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexer.MAINMENU));
        _sceneLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexer.GAME, LoadSceneMode.Additive));

        foreach (AsyncOperation a in _sceneLoading)
        {
            while (!a.isDone)
            {
                yield return null;
            }
            percentLoad += 25;
            LoadUpdateUI(percentLoad);

        }
        percentLoad = 50;
        LoadUpdateUI(percentLoad);

        yield return new WaitForSeconds(2f);
        percentLoad = 100;
        LoadUpdateUI(percentLoad);
        yield return new WaitForSeconds(0.5f);
        StateMachineController.Instance.ChangeTo<InGameState>();

    }

    private void LoadUpdateUI(int loadingValue)
    {
        float percent = (float)loadingValue/100;
        machine.LoadingBar.value = percent;
        machine.LoadingText.text = $"Loading...{loadingValue}%";

    }
}
