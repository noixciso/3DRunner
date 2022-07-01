using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;

    private const float _on = 1;
    private const float _off = 0;
    
    public void ResumeButtonClick(GameObject resumeButton)
    {
        _pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        Time.timeScale = _on;
    }
    
    public void PauseButtonClick(GameObject panel)
    {
        _pauseButton.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = _off;
    }
}
