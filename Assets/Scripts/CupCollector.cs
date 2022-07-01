using UnityEngine;
using UnityEngine.Events;

public class CupCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    public event UnityAction Collected;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Cup cup))
        {
            Collected?.Invoke();
            _player.IncrementScore();
            collision.gameObject.SetActive(false);
            PlayerPrefs.SetInt(ScoreStorage.Score.ToString(), ScoreStorage.Score);
        }
    }
}
