using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _backgroundSR;
    [SerializeField] private Color _dayColor;
    [SerializeField] private Color _nightColor;
    [SerializeField] private float _colorChangeSpeed;

    private float _deltaColor = 0f;
    private Color _targetColor = new Color(1f, 1f, 1f);

    private bool _transitionToNight = true;

    private void Update()
    {
        Color newColor;
        if (_transitionToNight)
        {
            newColor = Color.Lerp(
                _backgroundSR[0].color,
                _nightColor,
                _deltaColor);

            if (_deltaColor >= 1f)
            {
                _transitionToNight = false;
                _deltaColor = 0f;
            }
        }
        else
        {
            newColor = Color.Lerp(
                _backgroundSR[0].color,
                _dayColor,
                _deltaColor);

            if (_deltaColor >= 1f)
            {
                _transitionToNight = true;
                _deltaColor = 0f;
            }
        }

        _deltaColor += _colorChangeSpeed * Time.deltaTime;

        for (int i = 0; i < _backgroundSR.Length; i++)
        {
            _backgroundSR[i].color = newColor;
        }
    }
}
