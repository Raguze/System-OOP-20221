using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    static public Factory Instance { get; protected set; }

    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();



    private void Awake()
    {
        Instance = this;
        prefabs.Add("bullet", Resources.Load<GameObject>("Prefabs/Bullet"));
    }

    public GameObject Create (string key, Vector2 position, Quaternion rotation)
    {
        GameObject go = prefabs[key];
        return Instantiate(go, position, rotation);
    }
}
