using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _jumpForce = 6f;
    [SerializeField] float _timeToChangeRole = 0.38f;

    [SerializeField] private VoidEventChannelSO _jumpChannelEvent;
    [SerializeField] private FloatEventChannelSO _horizontalChannelEvent;

    private Rigidbody _rigidbody;

    public void Initialize(float jumpForce, VoidEventChannelSO jumpChannelEvent, FloatEventChannelSO horizontalChannelEvent)
    {
        _jumpChannelEvent = jumpChannelEvent;
        _horizontalChannelEvent = horizontalChannelEvent;
        _jumpForce = jumpForce;
        Awake();
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void MoveToRole(float xPos)
    {
        transform.LeanMoveLocalX(xPos, _timeToChangeRole);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void EnableEvents()
    {

        _jumpChannelEvent.OnEventRaised += Jump;
        _horizontalChannelEvent.OnEventRaised += MoveToRole;
    }

    private void DisableEvents()
    {

        _jumpChannelEvent.OnEventRaised -= Jump;
        _horizontalChannelEvent.OnEventRaised -= MoveToRole;
    }

    private void OnEnable()
    {
        EnableEvents();
    }

    private void OnDisable()
    {
        DisableEvents();
    }
}
