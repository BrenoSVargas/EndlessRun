using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolManager : MonoBehaviour
{
    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    public virtual void Initialize()
    {
        InitGame();
    }

    public virtual void InitGame()
    {
        FillPool();
    }

    protected GameObject GetRandomItem()
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

    protected void FillPool()
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
