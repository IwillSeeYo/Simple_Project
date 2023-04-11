using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WallMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector3.up * _speed*Time.deltaTime);
    }
}