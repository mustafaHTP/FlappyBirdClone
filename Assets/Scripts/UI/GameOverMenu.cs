using TMPro;
using UnityEngine;

public class GameOverMenu : UIElement
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    private void OnEnable()
    {
        DisplayUserScore();
    }

    private void DisplayUserScore()
    {
        _scoreTMP.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
