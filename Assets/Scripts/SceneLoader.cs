using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private string _game = "Game";
    private string _startMenu = "StartMenu";
    private string _loseMenu = "LoseMenu";

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        SceneManager.LoadScene(_loseMenu);
    }
    
    public void NewGameButtonClick()
    {
        SceneManager.LoadScene(_game);
    }

    public void MenuButtonClick()
    {
        SceneManager.LoadScene(_startMenu);
    }
    
    public void ExitButtonClick()
    {
        Application.Quit();
    }
}