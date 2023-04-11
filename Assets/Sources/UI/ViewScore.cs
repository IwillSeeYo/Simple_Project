using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] ScoreData _scoreData;

    private void OnEnable()
    {
        _score.text = _scoreData.GetScore().ToString();
        _scoreData.ScoreChanged += OnMoneyChanget;
    }

    private void OnDisable()
    {
        _scoreData.ScoreChanged -= OnMoneyChanget;
    }

    private void OnMoneyChanget(int score)
    {
        _score.text = score.ToString();
    }
}
