using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event UnityAction CupCollected; // подписаться где будет звук собранной монеты
    
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Barrier barrier))
        {
            _player.ApplyDamage(barrier.Damage);
        }
        else if (collision.TryGetComponent(out Cup cup))
        {
            CupCollected?.Invoke();
            _player.IncrementScore();
            collision.gameObject.SetActive(false);
            PlayerPrefs.SetInt("_score", _player.Score);
        }
    }
}
