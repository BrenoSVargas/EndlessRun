using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float[] _rolePosX = new float[3];
    private int index = 1;
    private bool isMoving, isJumping;
    private Health _health;
    private PlayerInputActions _playerInputActions;
    private Movement _movement;
    private CapsuleCollider _collider;
    [SerializeField] private float _sensibilityTouchInput = 5f;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private VoidEventChannelSO _onDeadChannelEvent;
    [SerializeField] private VoidEventChannelSO _onJumpChannelEvent;
    [SerializeField] private FloatEventChannelSO _onHorizontalChannelEvent;


    public void Initialize(float roleLeft, float roleMid, float roleRight, VoidEventChannelSO deadChannel,
        VoidEventChannelSO jumpChannel, FloatEventChannelSO horizontalChannel, float sensibilityTouch)
    {
        Awake();

        _rolePosX[0] = roleLeft;
        _rolePosX[1] = roleMid;
        _rolePosX[2] = roleRight;

        _sensibilityTouchInput = sensibilityTouch;

        _onDeadChannelEvent = deadChannel;
        _onJumpChannelEvent = jumpChannel;
        _onHorizontalChannelEvent = horizontalChannel;
    }

    private void Awake()
    {
        SearchComponents();
    }

    private void SearchComponents()
    {
        _health = GetComponent<Health>();
        _movement = GetComponent<Movement>();
        _collider = GetComponent<CapsuleCollider>();

        _playerInputActions = new PlayerInputActions();
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(_collider.bounds.center, new Vector3(_collider.bounds.center.x, _collider.bounds.min.y,
        _collider.bounds.center.z), _collider.radius * 0.01f, _groundLayer);
    }

    private void Input_Jump(InputAction.CallbackContext context)
    {
#if !UNITY_EDITOR
        if (context.ReadValue<float>() < _sensibilityTouchInput)
        {
            return;
        }
#endif
        if (isJumping || !IsGrounded())
        {
            return;
        }

        isJumping = true;

        _onJumpChannelEvent.RaiseEvent();
        StartCoroutine(WaitJumping());

    }

    private void Input_HorizontalMove(InputAction.CallbackContext context)
    {
#if !UNITY_EDITOR
        if (Mathf.Abs(context.ReadValue<float>()) < _sensibilityTouchInput)
        {
            return;
        }
#endif

        if (isMoving)
        {
            return;
        }
        isMoving = true;

        index += Mathf.RoundToInt(Mathf.Clamp(context.ReadValue<float>(), -1, 1));


        if (index < 0)
        {
            index = 0;
        }
        else if (index > 2)
        {
            index = 2;
        }

        _onHorizontalChannelEvent.RaiseEvent(_rolePosX[index]);

        StartCoroutine(WaitMoving(index));
    }

    private IEnumerator WaitJumping()
    {
        while (!IsGrounded())
        {
            isJumping = true;

            yield return null;
        }
        yield return null;

        isJumping = false;
    }

    private IEnumerator WaitMoving(int index)
    {
        while (Vector3.Distance(transform.localPosition, new Vector3(_rolePosX[index], transform.localPosition.y, transform.localPosition.z)) > 0.5f)
        {
            isMoving = true;
            yield return null;
        }
        isMoving = false;
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
