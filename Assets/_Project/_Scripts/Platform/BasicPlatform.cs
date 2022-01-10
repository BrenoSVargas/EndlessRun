using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlatform : Platform
{
    public override void Positioner()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));

        transform.Translate(0, Offset.y, 0);
        transform.Translate(Vector3.forward * Offset.x);
    }
}
