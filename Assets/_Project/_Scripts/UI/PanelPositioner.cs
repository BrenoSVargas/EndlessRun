using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PanelPositioner : MonoBehaviour
{
    public List<PanelPosition> positions;      
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void MoveTo(PanelPosition.PositionType positionName)
    {
        LeanTween.cancel(this.gameObject);

        PanelPosition pos = positions.Find(x => x.name == positionName);
        _rect.anchorMax = pos.anchorMax;
        _rect.anchorMin = pos.anchorMin;

        LeanTween.move(_rect, pos.position, pos.timeInMoving);
    }
}