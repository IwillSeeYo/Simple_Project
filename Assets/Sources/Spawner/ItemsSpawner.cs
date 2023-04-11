using UnityEngine;

public class ItemsSpawner : IItemSpawner
{
    public void Spawn(Vector3 position, GameObject prefab)
    {
        Object.Instantiate(prefab, position, Quaternion.identity);
    }
}