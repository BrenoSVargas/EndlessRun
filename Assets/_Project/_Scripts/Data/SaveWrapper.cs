using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWrapper : MonoBehaviour
{
    private const string defaultSaveFile = "save";
    public void Load()
    {
        GetComponent<SaveSystem>().Load(defaultSaveFile);
    }

    public void Save()
    {
        GetComponent<SaveSystem>().Save(defaultSaveFile);
    }

    public void Delete()
    {
        GetComponent<SaveSystem>().Delete(defaultSaveFile);

    }
}
