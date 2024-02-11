using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private SpriteRenderer _spriteRenderer;
    private float _spriteWidth;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteWidth = _spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        float deltaMove = _moveSpeed * Time.deltaTime;
        transform.position += Vector3.left * deltaMove;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("ParallaxTrigger"))
        {
            float jumpAmount = _spriteWidth * 2f;
            transform.position += Vector3.right * jumpAmount;
        }
    }
}
