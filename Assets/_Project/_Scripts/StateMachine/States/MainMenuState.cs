using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuState : State
{
    public override void Enter()
    {
        machine.gameIsRunning = false;
        machine.SaveMain.Save();
        SceneManager.LoadScene((int)SceneIndexer.MAINMENU, LoadSceneMode.Additive);


        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene s = SceneManager.GetSceneAt(i);
            if (s != SceneManager.GetSceneByBuildIndex((int)SceneIndexer.PERSISTANT))
            {
                SceneManager.UnloadSceneAsync(s);

            }
        }

        LoadData();
    }

    private void LoadData()
    {
        machine.SaveMain.Load();
    }
}
