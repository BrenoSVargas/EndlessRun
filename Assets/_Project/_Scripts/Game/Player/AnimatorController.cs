using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    private Animator _animator;


    [SerializeField] private VoidEventChannelSO _isDeadChannelEvent;
    [SerializeField] private VoidEventChannelSO _jumpChannelEvent;

    public void Initialize()
    {
        Awake();
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Jump()
    {
        _animator.SetTrigger(AnimatorParameters.Jump);
    }

    private void IsDead()
    {
        _animator.SetTrigger(AnimatorParameters.Dead);
    }
    private void EnableEvents()
    {
        _isDeadChannelEvent.OnEventRaised += IsDead;
        _jumpChannelEvent.OnEventRaised += Jump;
    }
    private void DisableEvents()
    {
        _isDeadChannelEvent.OnEventRaised -= IsDead;
        _jumpChannelEvent.OnEventRaised -= Jump;
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
