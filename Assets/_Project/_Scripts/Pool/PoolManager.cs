using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PoolManager : MonoBehaviour
{
    private static PoolManager _instance;
    public static PoolManager Instance => _instance;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    private void Awake()
    {
        _instance = this;
        FillPool();
    }

    public GameObject GetRandomItem()
    {
        Utils.Shuffle(pooledItems);

        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy)
            {
                return pooledItems[i];
            }
        }

        foreach (PoolItem item in items)
        {
            if (item.expendable)
            {
                GameObject instantiate = Instantiate(item.prefab);
                instantiate.SetActive(false);
                pooledItems.Add(instantiate);
                return instantiate;
            }
        }

        return null;
    }

    private void FillPool()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject instantiate = Instantiate(item.prefab);
                instantiate.SetActive(false);
                pooledItems.Add(instantiate);
            }
        }
    }
}
