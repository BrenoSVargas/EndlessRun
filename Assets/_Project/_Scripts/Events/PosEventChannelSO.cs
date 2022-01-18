using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Pos Event Channel")]
public class PosEventChannelSO : ScriptableObject
{

    public Action<Vector3> OnEventRaised;

    public void RaiseEvent(Vector3 value)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(value);
    }
}
