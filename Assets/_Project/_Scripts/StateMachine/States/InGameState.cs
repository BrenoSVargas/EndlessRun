using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : State
{
    public override void Enter()
    {
        machine.gameIsRunning = true;
    }
    public override void Exit()
    {
        machine.gameIsRunning = false;

    }
}
