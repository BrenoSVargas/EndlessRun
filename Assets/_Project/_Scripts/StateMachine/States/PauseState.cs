using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    public override void Enter()
    {
        machine.gameIsRunning = false;
    }
    public override void Exit()
    {
        machine.gameIsRunning = true;
    }
}
