using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private PlayerMovement _playerMovement;

    private static bool _isGameOver;
    public static bool IsGameOver
    {
        get
        {
            return _isGameOver;
        }
        set
        {
            _isGameOver = value;
        }
    }

    private void OnEnable()
    {
        CubeRaycast.OnGameOver += ShowGameOverUI;
    }
    private void OnDisable()
    {
        CubeRaycast.OnGameOver -= ShowGameOverUI;
    }

    private void ShowGameOverUI()
    {
        _gameOverUI.SetActive(true);
    }

    public void HideGameOverUI()
    {
        _gameOverUI.SetActive(false);
    }
}
