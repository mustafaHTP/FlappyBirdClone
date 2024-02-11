using TMPro;
using UnityEngine;

public class Score : UIElement
{
    [SerializeField] private TextMeshProUGUI _scoreTextTMP;

    private void Update()
    {
        Scorer scorer = FindAnyObjectByType<Scorer>(FindObjectsInactive.Include);
        _scoreTextTMP.text = $"{scorer?.Score}";
    }
}
