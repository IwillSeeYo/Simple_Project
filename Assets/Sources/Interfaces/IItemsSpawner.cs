using UnityEngine;

public interface IItemSpawner
{
    public void Spawn(Vector3 position, GameObject prefab);
}