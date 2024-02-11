using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _persistentObjectPrefab;

    private static bool _hasSpawned = false;

    private void Awake()
    {
        if (!_hasSpawned)
        {
            SpawnPersistentObject();
        }
    }

    private void SpawnPersistentObject()
    {
        GameObject spawnedObject = Instantiate(_persistentObjectPrefab);
        DontDestroyOnLoad(spawnedObject);
        _hasSpawned = true;
    }
}
