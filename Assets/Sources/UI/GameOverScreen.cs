using System;
using TMPro;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreData _scoreData;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TMP_Text _score;

    private event Action GameRestart;

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        Time.timeScale = 1;
        UpdateCoinsCount();
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _player.Died += OnDied;

    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _player.Died -= OnDied;
    }

    private void OnRestartButtonClick()
    {
        GameRestart?.Invoke();
        UpdateCoinsCount();

        SceneManager.LoadScene(1);
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        Time.timeScale = 1;
    }

    private void OnDied()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        Time.timeScale = 0;
    }

    private void UpdateCoinsCount()
    {
        //
    }


}