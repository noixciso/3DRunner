using UnityEngine;

public class CupVFX : MonoBehaviour
{
    [SerializeField] private CupCollector _cupCollector;
    [SerializeField] private GameObject _effect;
    
    private void OnEnable()
    {
        _cupCollector.Collected += OnCollected;
    }

    private void OnDisable()
    {
        _cupCollector.Collected -= OnCollected;
    }
    
    private void OnCollected()
    {
        Instantiate(_effect, _cupCollector.transform.position, Quaternion.identity);
    }
}
