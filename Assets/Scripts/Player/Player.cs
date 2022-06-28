using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private Vector3 _startPosition;
    private int _score;
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

    private void Start()
    {
        _startPosition = transform.position;
        Score = PlayerPrefs.GetInt(_score.ToString());
        ResetScore();

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

    private void ResetScore()
    {
        Score = 0;
        ScoreChanged?.Invoke(Score);
    }

    private void RespawnPlayer()
    {
        IsRespawn = true;
        gameObject.SetActive(false);
        Respawn?.Invoke();
        transform.position = _startPosition;
    }

    private void Die()
    {
        GameOver?.Invoke();
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