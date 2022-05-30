using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _score;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }


    // private void Update()
    // {
    //     _score.text = ((int) (_player.position.z / 2)).ToString();
    // }
    
    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}