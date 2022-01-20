using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineFollowPlayer : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCinemachine;
    [SerializeField] private VoidEventChannelSO _isDeadChannelEvent;

    private void Start()
    {
        _virtualCinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    private void UnfollowPlayer()
    {
        if (_virtualCinemachine == null)
        {
            return;
        }
        _virtualCinemachine.enabled = false;
    }
    private void EnableEvents()
    {
        _isDeadChannelEvent.OnEventRaised += UnfollowPlayer;
    }
    private void DisableEvents()
    {
        _isDeadChannelEvent.OnEventRaised -= UnfollowPlayer;
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
