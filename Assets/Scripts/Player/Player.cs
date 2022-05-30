using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private PlayerMover _mover;
    private int _score;
    private Vector3 _startPosition;
    private bool _isRespawn;

    public event UnityAction GameOver;
    public event UnityAction Respawn;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;

    public int Score
    {
        get => _score;
        private set => _score = value;
    }

    public bool IsRespawn
    {
        get => _isRespawn;
        private set => _isRespawn = value;
    }

    public Vector3 StartPosition
    {
        get => _startPosition;
        private set => _startPosition = value;
    }

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        StartPosition = gameObject.transform.position;

        Score = PlayerPrefs.GetInt(_score.ToString());
        Score = 0;

        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
        else if (_health > 0)
        {
            RespawnPlayer();
        }
    }

    public void ResetPlayer()
    {
        Score = 0;
        ScoreChanged?.Invoke(Score);
        //_mover.ResetPlayer();
    }

    public void RespawnPlayer() //доработать
    {
        IsRespawn = true;
        gameObject.SetActive(false);
        Respawn?.Invoke();
        gameObject.transform.position = StartPosition;
        
    }

    public void Die()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
    }

    public void IncrementScore()
    {
        Score++;
        ScoreChanged?.Invoke(Score);
    }

    public void SetActiveTrue()
    {
        gameObject.SetActive(true);
        IsRespawn = false;
    }
}