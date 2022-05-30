using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private AudioSource _cupCollectionNotification;

    private void Start()
    {
        _music.Play();
    }

    private void OnEnable()
    {
        _playerCollisionHandler.CupCollected += PlayCupCollectionNotification;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.CupCollected -= PlayCupCollectionNotification;
    }

    private void PlayCupCollectionNotification()
    {
        _cupCollectionNotification.Play();
    }
}
