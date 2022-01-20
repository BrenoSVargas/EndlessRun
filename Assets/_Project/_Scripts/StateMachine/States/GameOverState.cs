using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : State
{
    public override void Enter()
    {
        machine.SaveMain.Save();

        machine.gameIsRunning = false;
    }
    public override void Exit()
    {

    }
}
