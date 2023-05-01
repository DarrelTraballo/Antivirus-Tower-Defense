using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem {
    public string name;
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;
}

public class ObjectPool : MonoBehaviour {
    public static ObjectPool Instance;

    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        pooledObjects = new List<GameObject>();

        foreach (ObjectPoolItem item in itemsToPool) {
            for (int i = 0; i < item.amountToPool; i++) {
                GameObject obj = (GameObject) Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag)) {
                return pooledObjects[i];
            }
        }

        foreach (var item in itemsToPool) {
            if (item.objectToPool.tag == tag) {
                if (item.shouldExpand) {
                    GameObject obj = (GameObject) Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

    public void ReleaseObject(GameObject gameObject) {
        gameObject.SetActive(false);
    }
}
