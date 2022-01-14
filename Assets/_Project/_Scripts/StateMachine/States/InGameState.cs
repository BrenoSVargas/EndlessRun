using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : State
{
    private float timeCounter;
    public override void Enter()
    {
        machine.gameIsRunning = true;
    }
    public override void Exit()
    {
        machine.gameIsRunning = false;

    }
    public override void UpdateState()
    {
        timeCounter += Time.deltaTime;

        if (ScoreManager.Instance.SpeedGame < 1.5f && timeCounter >= machine.TimeLimit)
        {
            timeCounter = 0;
            ScoreManager.Instance.UpdateSpeedGame();
        }

        ScoreManager.Instance.ScorerUpdateEveryFrame();
    }
}
