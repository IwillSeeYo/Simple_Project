using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(ScoreData))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private const string TakeAnimation = "Take";

    private ScoreData _scoreData;
    private Animator _animator;

    public event Action Died;
    public event Action GameOver;

    private void Start()
    {
        _scoreData = GetComponent<ScoreData>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.TryGetComponent(out IScorable scorable))
        {
            _animator.Play(TakeAnimation);
            _scoreData.AddScore(scorable);
        }

        if(target.TryGetComponent(out Enemy enemy)|| target.TryGetComponent(out WallEdge wallEdge)) 
        {
            OnDied();
        }
    }

    private void OnDied()
    {
        Died?.Invoke();
        GameOver?.Invoke();
    }
}