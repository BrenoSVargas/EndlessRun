using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float timeToDestroy = 0.5f;
    [SerializeField] protected GameObject vFXToInstante;
    protected MeshRenderer meshRenderer;
    protected abstract void Effect();
}
