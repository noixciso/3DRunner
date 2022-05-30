using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;
    
    private string _game = "Game";
    private string _startMenu = "StartMenu";

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
    
    
    public void NewGameButtonClick()
    {
        SceneManager.LoadScene(_game);
        
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void MenuButtonClick()
    {
        SceneManager.LoadScene(_startMenu);
    }
}