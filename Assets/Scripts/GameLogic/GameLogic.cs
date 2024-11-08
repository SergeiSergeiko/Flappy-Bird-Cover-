﻿using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private GameOverZone _gameOverZone;
    [SerializeField] private GameOverWindow _gameOverWindow;
    [SerializeField] private StartGameWindow _startGameWindow;
    [SerializeField] private PoolObjectsResetter _poolObjectsResetter;

    private void OnEnable()
    {
        _rocket.Died += OnGameOver;
        _gameOverZone.GameOver += OnGameOver;
        _gameOverWindow.ButtonClicked += OnRestartButtonClicked;
        _startGameWindow.ButtonClicked += OnPlayButtonClicked;
    }

    private void OnDisable()
    {
        _rocket.Died -= OnGameOver;
        _gameOverZone.GameOver -= OnGameOver;
        _gameOverWindow.ButtonClicked -= OnRestartButtonClicked;
        _startGameWindow.ButtonClicked -= OnPlayButtonClicked;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startGameWindow.Open();
        _rocket.DisableInput();
    }

    private void OnGameOver()
    {
        _rocket.DisableInput();
        Time.timeScale = 0;
        _gameOverWindow.Open();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _rocket.Reset();
        _poolObjectsResetter.Reset();
    }

    private void OnPlayButtonClicked()
    {
        _startGameWindow.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        _gameOverWindow.Close();
        StartGame();
    }
}