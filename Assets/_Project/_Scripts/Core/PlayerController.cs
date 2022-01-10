using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Health _health;
    private Animator _animator;


    public void Initialize()
    {
        Awake();
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _health.OnGameOver += Health_GameOver;
    }

    private void Health_GameOver(bool isOver)
    {
        if (isOver)
            _animator.SetTrigger("isDead");
    }
}
