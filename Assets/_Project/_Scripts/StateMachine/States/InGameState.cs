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
    private void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= machine.TimeLimit)
        {
            
        }

        ScoreManager.Instance.ScorerUpdateEveryFrame();
    }
}
