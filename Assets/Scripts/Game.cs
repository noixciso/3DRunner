using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private GameObject _respawnScreen;
    [SerializeField] private Timer _timer;
    
    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _player.Respawn += OnRespawn;
    }

    private void OnDisable()
    {
        _player.Respawn -= OnRespawn;
    }

    private void OnRespawn()
    {
        StartCoroutine(ShowRespawnScreen());
    }

    private IEnumerator ShowRespawnScreen()
    {
        _pauseButton.SetActive(false);
        _respawnScreen.SetActive(true);
        yield return new WaitForSeconds(_timer.TimeStart);
        _respawnScreen.SetActive(false);
        _pauseButton.SetActive(true);
        _player.SetActiveTrue();
        _mover.RunSpeedIncrease();
    }
}
