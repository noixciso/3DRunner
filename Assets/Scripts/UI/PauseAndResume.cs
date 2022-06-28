using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;
    
    public void ResumeButtonClick(GameObject resumeButton)
    {
        _pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void PauseButtonClick(GameObject panel)
    {
        _pauseButton.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
