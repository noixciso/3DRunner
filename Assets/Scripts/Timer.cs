using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private float _timeStart = 3;
    private float _minTime = 0;
    private float _currentTime;

    public float TimeStart
    {
        get => _timeStart;
        private set => _timeStart = value;
    }

    public float CurrentTime
    {
        get { return _currentTime; }
        
        private set
        {
            _currentTime = Mathf.Clamp(value, _minTime, _timeStart);

            if (_currentTime <= _minTime)
            {
                _currentTime = _timeStart;
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