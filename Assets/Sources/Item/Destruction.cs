using UnityEngine;

public class Destruction : MonoBehaviour, IDestroyable
{
    private readonly Transform _transform;
    private readonly float _destroyHeight;

    public Destruction(Transform transform, float destroyHeight)
    {
        _transform = transform;
        _destroyHeight = destroyHeight;
    }

    public void Destroy(GameObject gameObject)
    {
        if (_transform.position.y >= _destroyHeight)
        {
            Object.Destroy(gameObject);
        }
    }
}