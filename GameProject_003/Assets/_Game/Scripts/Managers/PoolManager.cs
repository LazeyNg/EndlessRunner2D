using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField]
    private int _defaultPoolSize = 10;
    [SerializeField]
    private GameObject objectPrefab;
    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        GeneratePool(_defaultPoolSize);
    }

    List<GameObject> GeneratePool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject poolObject = Instantiate(objectPrefab, this.transform);
            poolObject.SetActive(false);

            objectPool.Add(poolObject);
        }

        return objectPool;
    }

    public GameObject RequestObject()
    {
        foreach (GameObject obj in objectPool)
        {
            if (obj.activeInHierarchy == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(objectPrefab);
        objectPool.Add(newObj);

        return newObj;
    }

    public void DespawnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
