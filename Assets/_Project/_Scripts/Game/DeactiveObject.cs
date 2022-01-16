using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveObject : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _newPlatformEvent = default;
    private void OnTriggerExit(Collider other)
    {
        LimitOfScene limit = other.GetComponent<LimitOfScene>();

        if (!limit)
        {
            return;
        }

        _newPlatformEvent.RaiseEvent();
        gameObject.SetActive(false);
    }
}
