using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private CupCollector _cupCollector;
    [SerializeField] private AudioSource _cupCollectionNotification;

    private void Start()
    {
        _music.Play();
    }

    private void OnEnable()
    {
        _cupCollector.Collected += PlayCollectionNotification;
    }

    private void OnDisable()
    {
        _cupCollector.Collected -= PlayCollectionNotification;
    }

    private void PlayCollectionNotification()
    {
        _cupCollectionNotification.Play();
    }
}
