using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe")
            || collision.gameObject.CompareTag("Ground"))
        {
            GameManager.Instance.EndGame();
        }
    }
}
