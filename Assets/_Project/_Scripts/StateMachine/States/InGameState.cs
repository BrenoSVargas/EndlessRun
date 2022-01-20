using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : State
{
    private float timeCounter;

    public override void Enter()
    {
        machine.OnGameIsStarted.RaiseEvent();
        machine.gameIsRunning = true;
    }
    public override void Exit()
    {
        machine.gameIsRunning = false;
    }
    public override void UpdateState()
    {
        timeCounter += Time.deltaTime;

        if (machine.SpeedGame < machine.MaxSpeedGame && timeCounter >= machine.TimeLimit)
        {
            timeCounter = 0;
            UpdateSpeedGame();

            if (machine.SpeedGame > machine.MaxSpeedGame)
            {
                machine.SpeedGame = machine.MaxSpeedGame;
            }
        }

        machine.OnScoreUpdateEvent.RaiseEvent();
    }

    private void UpdateSpeedGame()
    {
        machine.SpeedGame *= machine.TimeMultiplayerSpeed;
    }
}
