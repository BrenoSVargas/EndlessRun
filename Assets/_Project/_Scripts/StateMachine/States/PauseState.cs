using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    public override void Enter()
    {
        machine.gameIsRunning = true;
        Time.timeScale = 0f;
    }
    public override void Exit()
    {
        machine.gameIsRunning = false;
        Time.timeScale = 1f;


    }
}
