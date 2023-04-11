using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private float _minSpawnDelay;
    [SerializeField] private float _maxSpawnDelay;

    private Collider _spawnArea;
    private ItemsSpawner _itemsSpawner;
    private SpawnDelay _delaySpawn;

    private void Awake()
    {
        _spawnArea = GetComponent<Collider>();
        _itemsSpawner = new ItemsSpawner();
        _delaySpawn = gameObject.AddComponent<SpawnDelay>();
    }

    private void OnEnable()
    {
        _delaySpawn.StartDelay(_minSpawnDelay, _maxSpawnDelay);
        _delaySpawn.Spawn += OnSpawnItem;
    }

    private void OnDisable()
    {
        _delaySpawn.StopDelay();
        _delaySpawn.Spawn -= OnSpawnItem;
    }

    private void OnSpawnItem()
    {
        var randomItem = _itemData.GetRandomItem();

        Vector3 position = new Vector3();
        position.x = Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
        position.y = Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y);
        position.z = Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z);

        _itemsSpawner.Spawn(position, randomItem.Prefab);
    }
}