using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Destruction))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SphereCollider))]

public class Item : MonoBehaviour, IScorable
{
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyHeight;
    [SerializeField] private int _point;

    private Movement _movement;
    private Destruction _destruction;

    private void Awake()
    {
        _movement = new Movement(transform, _speed);
        _destruction = new Destruction(transform, _destroyHeight);
    }

    private void Update()
    {
        _movement.Move();
        _destruction.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            Instantiate(_deathEffect, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }

    public int GetScore()
    {
        return _point;
    }
}