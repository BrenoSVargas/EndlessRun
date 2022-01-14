using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveObject : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        LimitOfScene limit = other.GetComponent<LimitOfScene>();
        
        if (!limit) return;
        
        WorldGenerator.Instance.GeneratePlatform();
        gameObject.SetActive(false);
    }
}
