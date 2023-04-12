using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public sealed class WallTrigger : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WallMovement wallMovement))
        {
            wallMovement.transform.position = _spawnPoint.position;
        }
    }
}
