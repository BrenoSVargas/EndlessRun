using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private StateMachineController _machine;

    private void Awake()
    {
        _machine = StateMachineController.Instance;
    }

    private void FixedUpdate()
    {
        if (!_machine.gameIsRunning)
        {
            return;
        }

        transform.Translate(Vector3.right * _machine.SpeedGame * Time.deltaTime);
    }
}
