using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public bool IsRespawn
    {
        get => _isRespawn;
        private set => _isRespawn = value;
    }
    
    [SerializeField] private int _health;
    
    private Vector3 _startPosition;
    private bool _isRespawn;
    private int _minHealth;

    public event UnityAction GameOver;
    public event UnityAction Respawn;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        _minHealth = 0;
        _startPosition = transform.position;
        PlayerPrefs.GetInt(ScoreStorage.Score.ToString()); ////aaaaaaaaa
        ResetScore();

        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= _minHealth)
        {
            Die();
        }
        else if (_health > _minHealth)
        {
            RespawnPlayer();
        }
    }

    private void ResetScore()
    {
        ScoreStorage.Score = 0;
        ScoreChanged?.Invoke(ScoreStorage.Score);
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
        ScoreStorage.Score++;
        ScoreChanged?.Invoke(ScoreStorage.Score);
    }

    public void SetPlayerActive()
    {
        gameObject.SetActive(true);
        IsRespawn = false;
    }
}