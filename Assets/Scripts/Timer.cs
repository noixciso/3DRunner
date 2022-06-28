using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    
    private float _timeStart = 3;
    private float _currentTime;

    public float TimeStart
    {
        get => _timeStart;
        private set => _timeStart = value;
    }

    public float CurrentTime
    {
        get
        {
            return _currentTime;
        }
        private set
        {
            if (_currentTime <= 0)
            {
                _currentTime = _timeStart;
            }
            else
            {
                _currentTime = value;
            }
        }
    }
    
    private void Start()
    {
        CurrentTime = TimeStart;
        _timerText.text = CurrentTime.ToString();
    }

    private void Update()
    {
        CurrentTime -= Time.deltaTime;
        _timerText.text = Mathf.Round(CurrentTime).ToString();
    }
}
