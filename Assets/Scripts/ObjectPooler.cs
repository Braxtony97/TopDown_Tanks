using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }

    public static ObjectPooler Instance; // Синглтон
                                         // Static - можем обращаться через класс, а не экземпляр объекта
    [SerializeField] private List<Pool> _pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> _poolDictionary; // С помощью ключа будем обращаться к нужному пулу

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            _poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Transform shootPoint)
    {
        if (!_poolDictionary.ContainsKey(tag))
            return null;

        GameObject objectToSpawn = _poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = shootPoint.position;
        objectToSpawn.transform.rotation = shootPoint.rotation;

        _poolDictionary[tag].Enqueue(objectToSpawn); // Последний в очерерди будет

        return objectToSpawn;
    }
}
