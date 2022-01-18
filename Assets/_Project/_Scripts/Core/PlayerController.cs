using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float[] _rolePosX = new float[3];
    private int index = 1;
    private Health _health;
    private PlayerInputActions _playerInputActions;
    private Movement _movement;

    [SerializeField] private VoidEventChannelSO _deadChannelEvent;
    [SerializeField] private VoidEventChannelSO _jumpChannelEvent;
    [SerializeField] private FloatEventChannelSO _horizontalChannelEvent;


    public void Initialize(float roleLeft, float roleMid, float roleRight)
    {
        Awake();

        _rolePosX[0] = roleLeft;
        _rolePosX[1] = roleMid;
        _rolePosX[2] = roleRight;
    }
    private void Awake()
    {
        _health = GetComponent<Health>();
        _movement = GetComponent<Movement>();

        _playerInputActions = new PlayerInputActions();
    }
    private void Start()
    {
        _deadChannelEvent.OnEventRaised += IsDeadEvent;
    }
    private void Input_Jump(InputAction.CallbackContext context)
    {
        _jumpChannelEvent.RaiseEvent();
    }

    private void Input_HorizontalMove(InputAction.CallbackContext context)
    {
        index += Mathf.RoundToInt(context.ReadValue<float>());

        if (index < 0)
            index = 0;
        else if (index > 2)
            index = 2;

        _horizontalChannelEvent.RaiseEvent(_rolePosX[index]);
    }

    private void IsDeadEvent()
    {
        DisableInputs();
    }

    private void EnableInputs()
    {
        _playerInputActions.Player.Jump.performed += Input_Jump;
        _playerInputActions.Player.Jump.Enable();

        _playerInputActions.Player.HorizontalMove.performed += Input_HorizontalMove;
        _playerInputActions.Player.HorizontalMove.Enable();
    }

    private void DisableInputs()
    {
        _playerInputActions.Player.Jump.performed -= Input_Jump;
        _playerInputActions.Player.Jump.Disable();

        _playerInputActions.Player.HorizontalMove.performed -= Input_HorizontalMove;
        _playerInputActions.Player.HorizontalMove.Disable();
    }

    private void OnEnable()
    {
        EnableInputs();
    }

    private void OnDisable()
    {
        DisableInputs();
    }
}
