using TMPro;
using UnityEngine;

public class ViewScoreInMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    
    private void Start()
    {
        int score = PlayerPrefs.GetInt(ScoreStorage.Score.ToString());
        _scoreText.text = score.ToString();
    }
}
