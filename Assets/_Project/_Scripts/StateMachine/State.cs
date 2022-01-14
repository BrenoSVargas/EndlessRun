using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected StateMachineController machine { get { return StateMachineController.Instance; } }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void UpdateState()
    {

    }
}
