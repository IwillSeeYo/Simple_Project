using UnityEngine;

public sealed class Movement : MonoBehaviour, IMovable
{
    private readonly float _speed;
    private readonly Transform _transform;

    public Movement(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public void Move()
    {
        _transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}