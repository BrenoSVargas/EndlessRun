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
        PanelPosition pos = positions.Find(x => x.name == positionName);
        _rect.anchorMax = pos.anchorMax;
        _rect.anchorMin = pos.anchorMin;
        StopAllCoroutines();
        StartCoroutine(Mover(pos));
    }

    private IEnumerator Mover(PanelPosition pos)
    {
        Vector3 startPos = transform.localPosition;
        while (Vector3.Distance(transform.localPosition, pos.position) >= 5)
        {
            _rect.localPosition = Vector3.Lerp(transform.localPosition, pos.position, 0.15f);
            yield return null;
        }

        if (pos.name == PanelPosition.PositionType.Show)
        {
            while (Vector3.Distance(transform.localPosition, pos.position) <= 250)
            {
                _rect.localPosition = Vector3.Lerp(transform.localPosition, startPos, 0.005f);
                yield return null;
            }

            while (Vector3.Distance(transform.localPosition, pos.position) >= 2)
            {
                _rect.localPosition = Vector3.Lerp(transform.localPosition, pos.position, 0.02f);
                yield return null;
            }
        }
        _rect.localPosition = pos.position;

    }
}