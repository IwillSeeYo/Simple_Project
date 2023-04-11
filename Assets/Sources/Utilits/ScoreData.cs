using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreData : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> ScoreChanged;

    public void AddScore(IScorable scorable)
    {
        _score += scorable.GetScore();
        ScoreChanged?.Invoke(_score);
    }

    public int GetScore()
    {
        return _score;
    }
}