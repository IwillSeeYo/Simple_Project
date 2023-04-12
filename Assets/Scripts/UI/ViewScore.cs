using TMPro;
using UnityEngine;

public sealed class ViewScore : MonoBehaviour
{
    private const string AnimationScale = "ScoreScale";

    [SerializeField] private TMP_Text _score;
    [SerializeField] ScoreData _scoreData;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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
        _animator.Play(AnimationScale);
    }
}
