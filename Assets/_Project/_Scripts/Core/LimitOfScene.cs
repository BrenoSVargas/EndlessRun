using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LimitOfScene : MonoBehaviour
{
    [SerializeField] private float sizeOfScene;

    private void Initialize(float limit){
        sizeOfScene = limit;
        Awake();
    }
    private void Awake()
    {
        SphereCollider limitCol = GetComponent<SphereCollider>();
        limitCol.radius = sizeOfScene;
    }
}
