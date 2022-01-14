using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    [SerializeField] private PlatformsType _typePlatform;
    [SerializeField] private Vector3 _offsetToInstantiate;
    [SerializeField] private float _sumPosZ = 0f;
    [SerializeField]
    [Range(0, 10)] protected int chanceOfObstacle;
    [SerializeField]
    protected List<Obstacle> obstacles = new List<Obstacle>();

    public float SumPosZ => _sumPosZ;
    public Vector3 Offset => _offsetToInstantiate;
    public PlatformsType PlatformType => _typePlatform;

    public abstract void SetPlatform();

}
