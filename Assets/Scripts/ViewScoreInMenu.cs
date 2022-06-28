using TMPro;
using UnityEngine;

public class ViewScoreInMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    
    private string _score = "_score";

    private void Start()
    {
        int score = PlayerPrefs.GetInt(_score);
        _scoreText.text = score.ToString();
    }
}
