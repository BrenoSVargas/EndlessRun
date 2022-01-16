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
    private Animator _animator;
    private PlayerInputActions _playerInputActions;
    private Movement _movement;

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
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();

        _playerInputActions = new PlayerInputActions();
    }
    private void Start()
    {
        _health.OnGameOver += Health_GameOver;
    }
    private void Input_Jump(InputAction.CallbackContext context)
    {
        _animator.SetTrigger(AnimatorParameters.Jump);
        _movement.Jump();
    }

    private void Input_HorizontalMove(InputAction.CallbackContext context)
    {
        index += Mathf.RoundToInt(context.ReadValue<float>());

        if (index < 0)
            index = 0;
        else if (index > 2)
            index = 2;

        _movement.MoveToRole(_rolePosX[index]);
    }

    private void Health_GameOver(bool isOver)
    {
        if (isOver)
            _animator.SetTrigger(AnimatorParameters.Dead);
    }

    private void OnEnable()
    {
        _playerInputActions.Player.Jump.performed += Input_Jump;
        _playerInputActions.Player.Jump.Enable();

        _playerInputActions.Player.HorizontalMove.performed += Input_HorizontalMove;
        _playerInputActions.Player.HorizontalMove.Enable();
    }


    private void OnDisable()
    {
        _playerInputActions.Player.Jump.performed -= Input_Jump;
        _playerInputActions.Player.Jump.Disable();

        _playerInputActions.Player.HorizontalMove.performed -= Input_HorizontalMove;
        _playerInputActions.Player.HorizontalMove.Disable();
    }
}
