using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : Platform
{
    [SerializeField]
    private float[] _rolesPosition = new float[3];
    public override void SetPlatform()
    {
        float x = _rolesPosition[Random.Range(0,_rolesPosition.Length)];

        transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));

        transform.Translate(0, Offset.y, 0);
        transform.Translate(Vector3.forward * x);
    }
}
