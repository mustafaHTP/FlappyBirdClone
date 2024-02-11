using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] private AudioSource _scoreSFX;

    private int _score = 0;

    public int Score { get => _score; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreTrigger"))
        {
            ++_score;
            if (!_scoreSFX.isPlaying)
            {
                _scoreSFX.Play();
            }
        }
    }
}
