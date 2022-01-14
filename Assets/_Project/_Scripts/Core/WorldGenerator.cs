using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WorldGenerator : MonoBehaviour
{
    private static WorldGenerator _instance;
    public static WorldGenerator Instance { get { return _instance; } }
    [SerializeField] private int _numberOfPlatforms = 20;

    private Transform _savedPosPlatform;
    private Transform lastPlatformTransform;


    public void Initialize()
    {
        _numberOfPlatforms = 20;
        Awake();
    }
    private void Awake()
    {
        _instance = this;

        _savedPosPlatform = new GameObject("SavedPosPlatform").transform;

        _savedPosPlatform.position = new Vector3(0, 0, 0);
        _savedPosPlatform.Rotate(new Vector3(0, 0, 0));

    }


    private void Start()
    {
        GeneratePlatforms();
    }


    private void GeneratePlatforms()
    {
        for (int i = 0; i < _numberOfPlatforms; i++)
        {
            GeneratePlatform();
        }
    }
    public void GeneratePlatform()
    {
        GameObject platformGO = PoolManager.Instance.GetRandomItem();

        if (!platformGO) return;

        platformGO.SetActive(true);

        if (lastPlatformTransform != null)
        {
            _savedPosPlatform.transform.position = new Vector3(0, 0, lastPlatformTransform.position.z + platformGO.GetComponent<Platform>().SumPosZ);
        }

        platformGO.transform.position = _savedPosPlatform.position;

        lastPlatformTransform = platformGO.transform;

        platformGO.GetComponent<Platform>().SetPlatform();
    }
}
