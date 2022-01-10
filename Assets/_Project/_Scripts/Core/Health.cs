using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<bool> OnGameOver;
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obs = other.gameObject.GetComponent<Obstacle>();
        if (!obs) return;
        GameOver(true);
    }

    private void GameOver(bool isOver)
    {
        StateMachineController.Instance.ChangeTo<GameOverState>();
        OnGameOver?.Invoke(isOver);
    }
}
