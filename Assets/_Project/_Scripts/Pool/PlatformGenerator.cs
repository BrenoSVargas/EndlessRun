using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlatformGenerator : PoolManager
{
    [SerializeField] private int _numberOfPlatforms = 20;
    [SerializeField] private VoidEventChannelSO _newPlatformEvent = default;
    [SerializeField] private VoidEventChannelSO _initGameEvent = default;

    private Transform _savedPosPlatform;
    private Transform _lastPlatformTransform;


    public override void Initialize(PoolItem[] itemArray)
    {
        base.Initialize(itemArray);
        _numberOfPlatforms = 20;
    }

    protected override void InitGame()
    {
        base.InitGame();

        _savedPosPlatform = new GameObject("SavedPosPlatform").transform;

        _savedPosPlatform.position = new Vector3(0, 0, -20);
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

    private void GeneratePlatform()
    {
        GameObject platformGO = GetRandomItem();

        if (!platformGO) return;

        platformGO.SetActive(true);

        if (_lastPlatformTransform != null)
        {
            _savedPosPlatform.transform.position = new Vector3(0, 0, _lastPlatformTransform.position.z + platformGO.GetComponent<Platform>().SumPosZ);
        }
        else
        {
            _savedPosPlatform.position = new Vector3(0, 0, _savedPosPlatform.position.z + platformGO.GetComponent<Platform>().SumPosZ);
        }

        platformGO.transform.position = _savedPosPlatform.position;

        _lastPlatformTransform = platformGO.transform;

        platformGO.GetComponent<Platform>().SetPlatform();
    }

    private void EnableEvents()
    {
        _newPlatformEvent.OnEventRaised += GeneratePlatform;
        _initGameEvent.OnEventRaised += InitGame;

    }

    private void DisableEvents()
    {
        _newPlatformEvent.OnEventRaised -= GeneratePlatform;
        _initGameEvent.OnEventRaised -= InitGame;

    }

    private void OnEnable()
    {
        EnableEvents();
    }

    private void OnDisable()
    {
        DisableEvents();
    }
}
