using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveableEntity : MonoBehaviour
{

    [SerializeField] string uniqueIdentifier = "";
    static Dictionary<string, SaveableEntity> globalLookup = new Dictionary<string, SaveableEntity>();

    public void Initialize(string identifier){
        uniqueIdentifier = identifier;
    }
    public string GetUniqueIdentifier()
    {
        return uniqueIdentifier;
    }
    public object CaptureState()
    {
        Dictionary<string, object> state = new Dictionary<string, object>();
        foreach (ISaveable saveable in GetComponents<ISaveable>())
        {
            state[saveable.GetType().ToString()] = saveable.CaptureData();
        }

        return state;
    }

    public void RestoreState(object state)
    {
        Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
        foreach (ISaveable saveable in GetComponents<ISaveable>())
        {
            string typeString = saveable.GetType().ToString();
            if (stateDict.ContainsKey(typeString))
            {
                saveable.RestoreData(stateDict[typeString]);
            }
        }
    }
}
