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

    [SerializeField] private VoidEventChannelSO _onDeadChannelEvent;
    [SerializeField] private VoidEventChannelSO _onJumpChannelEvent;
    [SerializeField] private FloatEventChannelSO _onHorizontalChannelEvent;


    public void Initialize(float roleLeft, float roleMid, float roleRight, VoidEventChannelSO deadChannel,
        VoidEventChannelSO jumpChannel, FloatEventChannelSO horizontalChannel)
    {
        Awake();

        _rolePosX[0] = roleLeft;
        _rolePosX[1] = roleMid;
        _rolePosX[2] = roleRight;

        _onDeadChannelEvent = deadChannel;
        _onJumpChannelEvent = jumpChannel;
        _onHorizontalChannelEvent = horizontalChannel;
    }
    private void Awake()
    {
        _health = GetComponent<Health>();
        _movement = GetComponent<Movement>();

        _playerInputActions = new PlayerInputActions();
    }
    private void Input_Jump(InputAction.CallbackContext context)
    {
        _onJumpChannelEvent.RaiseEvent();
    }

    private void Input_HorizontalMove(InputAction.CallbackContext context)
    {
        index += Mathf.RoundToInt(context.ReadValue<float>());

        if (index < 0)
            index = 0;
        else if (index > 2)
            index = 2;

        _onHorizontalChannelEvent.RaiseEvent(_rolePosX[index]);
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
    private void EnableEvents()
    {
        _onDeadChannelEvent.OnEventRaised += IsDeadEvent;

    }

    private void DisableInputs()
    {
        _playerInputActions.Player.Jump.performed -= Input_Jump;
        _playerInputActions.Player.Jump.Disable();

        _playerInputActions.Player.HorizontalMove.performed -= Input_HorizontalMove;
        _playerInputActions.Player.HorizontalMove.Disable();
    }

    private void DisableEvents()
    {
        _onDeadChannelEvent.OnEventRaised -= IsDeadEvent;
    }


    private void OnEnable()
    {
        EnableInputs();
        EnableEvents();
    }

    private void OnDisable()
    {
        DisableInputs();
        DisableEvents();
    }
}
