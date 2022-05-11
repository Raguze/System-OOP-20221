using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FactoryItem
{
    None,
    Bullet
}

public class Factory : MonoBehaviour
{
    static public Factory Instance { get; protected set; }

    private Dictionary<FactoryItem, GameObject> prefabs = new Dictionary<FactoryItem, GameObject>();
    private Dictionary<FactoryItem, Queue<IPoolable>> pool = new Dictionary<FactoryItem, Queue<IPoolable>>();


    private void Awake()
    {
        Instance = this;
        prefabs.Add(FactoryItem.Bullet, Resources.Load<GameObject>("Prefabs/Bullet"));

        Register(FactoryItem.Bullet, 300);

    }


    private void Register(FactoryItem key, int count)
    {
        
        GameObject prefab = prefabs[key];
        Debug.Log(prefab);
        Queue<IPoolable> queue = new Queue<IPoolable>();
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(prefab, Vector2.zero,Quaternion.identity);

            IPoolable poolable = go.GetComponent<IPoolable>();
            poolable.Recycle();
            queue.Enqueue(poolable);
        }
        pool.Add(key, queue);
    }

    public GameObject GetObject (FactoryItem key)
    {
        IPoolable obj = pool[key].Dequeue();
        obj.TurnOn();
        return (obj as MonoBehaviour).gameObject;
    }

    public void ReturnObject(FactoryItem key, IPoolable obj)
    {
        obj.Recycle();
        pool[key].Enqueue(obj);
    }
}
