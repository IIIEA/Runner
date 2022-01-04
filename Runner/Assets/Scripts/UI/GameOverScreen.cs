using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverScreenGroup;

    private void Awake()
    {
        _gameOverScreenGroup = GetComponent<CanvasGroup>();
        _gameOverScreenGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restart.onClick.AddListener(OnRestartButtonClick);
        _exit.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restart.onClick.RemoveListener(OnRestartButtonClick);
        _exit.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnDied()
    {
        _gameOverScreenGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
