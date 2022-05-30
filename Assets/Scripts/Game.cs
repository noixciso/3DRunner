using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _respawnScreen;
    [SerializeField] private Timer _timer;
    
    private int _loseMenu = 2;
    

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
        _player.Respawn += OnRespawn;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _player.Respawn -= OnRespawn;
    }

    private void OnRespawn()
    {
        StartCoroutine(ShowRespawnScreen());
    }
    
    private void OnGameOver()
    {
        SceneManager.LoadScene(_loseMenu);
    }

    private IEnumerator ShowRespawnScreen()
    {
        _pauseButton.SetActive(false);
        _respawnScreen.SetActive(true);
        yield return new WaitForSeconds(_timer.TimeStart);
        _respawnScreen.SetActive(false);
        _pauseButton.SetActive(true);
        _player.SetActiveTrue();
    }
}
