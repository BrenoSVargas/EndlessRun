using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LimitOfScene : MonoBehaviour
{
    [SerializeField] private float sizeOfScene;
    // Start is called before the first frame update
    private void Initialize(){
        sizeOfScene = 150f;
        Awake();
    }
    private void Awake()
    {
        SphereCollider limitCol = GetComponent<SphereCollider>();
        limitCol.radius = sizeOfScene;
    }
}
