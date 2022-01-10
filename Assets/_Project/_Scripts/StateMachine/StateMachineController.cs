using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StateMachineController : MonoBehaviour
{
    private static StateMachineController _instance;
    public static StateMachineController Instance { get { return _instance; } }

    private State _current;
    public State current { get { return _current; } }
    private bool _busy;

    public bool gameIsRunning;

    public void Initialize()
    {
        _busy = false;
        Awake();
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        ChangeTo<InGameState>();
    }

    public void ChangeTo<T>() where T : State
    {
        State state = GetState<T>();

        if (_current != state)
            ChangeState(state);
    }

    private T GetState<T>() where T : State
    {
        T target = GetComponent<T>();

        if (target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    private void ChangeState(State value)
    {
        if (_busy)
            return;

        _busy = true;

        if (_current != null)
        {
            _current.Exit();
        }

        _current = value;

        if (_current != null)
        {
            _current.Enter();
        }

        _busy = false;

    }


}
