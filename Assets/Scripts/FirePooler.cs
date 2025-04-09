using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;

public class FirePooler : MonoBehaviour
{
    public static FirePooler instance;
    public List<GameObject> poolObjects;
    public GameObject prefab;
    public int amountToPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        poolObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(prefab);
            tmp.SetActive(false);
            poolObjects.Add(tmp);
        }
    }

    public GameObject getPoolObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                if (poolObjects[i] != null)
                {
                    return poolObjects[i];
                }
            }
        }
        return null;
    }
}
