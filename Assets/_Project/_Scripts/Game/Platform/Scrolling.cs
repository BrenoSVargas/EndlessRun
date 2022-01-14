using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (!StateMachineController.Instance.gameIsRunning) return;

        transform.Translate(Vector3.right * ScoreManager.Instance.SpeedGame);
    }
}
