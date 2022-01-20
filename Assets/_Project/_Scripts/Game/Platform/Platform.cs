using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    [SerializeField] private PlatformsType _typePlatform;
    [SerializeField] private Vector3 _offsetToInstantiate;
    [SerializeField] private float _sumPosZ = 0f;


    public float SumPosZ => _sumPosZ;
    public Vector3 Offset => _offsetToInstantiate;
    public PlatformsType PlatformType => _typePlatform;

    public abstract void SetPlatform();

}
