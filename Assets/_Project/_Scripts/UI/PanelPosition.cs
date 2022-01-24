using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PanelPosition
{
    public enum PositionType
    {
        Show,
        Hide,
    }
    public PositionType name;
    public Vector3 position;
    public Vector2 anchorMin;
    public Vector2 anchorMax;
    public float timeInMoving;
}
