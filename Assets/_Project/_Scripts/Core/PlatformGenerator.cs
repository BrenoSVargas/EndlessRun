using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlatformGenerator : PoolManager
{
    [SerializeField] private int _numberOfPlatforms = 20;
    [SerializeField] private VoidEventChannelSO _newPlatformEvent = default;

    private Transform _savedPosPlatform;
    private Transform _lastPlatformTransform;


    public override void Initialize()
    {
        _numberOfPlatforms = 20;
    }
    private void Start()
    {
        _newPlatformEvent.OnEventRaised += GeneratePlatform;
        InitGame();
    }

    public override void InitGame()
    {
        base.InitGame();

        _savedPosPlatform = new GameObject("SavedPosPlatform").transform;

        _savedPosPlatform.position = new Vector3(0, 0, 0);
        _savedPosPlatform.Rotate(new Vector3(0, 0, 0));
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
        GameObject platformGO = GetRandomItem();

        if (!platformGO) return;

        platformGO.SetActive(true);

        if (_lastPlatformTransform != null)
        {
            _savedPosPlatform.transform.position = new Vector3(0, 0, _lastPlatformTransform.position.z + _lastPlatformTransform.GetComponent<Platform>().SumPosZ);
        }

        platformGO.transform.position = _savedPosPlatform.position;

        _lastPlatformTransform = platformGO.transform;

        platformGO.GetComponent<Platform>().SetPlatform();
    }
}
