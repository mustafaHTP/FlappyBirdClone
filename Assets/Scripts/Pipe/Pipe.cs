using UnityEngine;
using Random = UnityEngine.Random;

public class Pipe : MonoBehaviour
{
    [Header("General Settings")]
    [Space(5)]
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _distanceBetweenPipes;
    [SerializeField] private Transform _topPipe;
    [SerializeField] private Transform _bottomPipe;

    [Header("Pipe Color Settings")]
    [Space(5)]
    [SerializeField] private Color[] _pipeColors;
    [SerializeField] private SpriteRenderer _topPipeSR;
    [SerializeField] private SpriteRenderer _bottomPipeSR;

    private void Awake()
    {
        SetRandomPipeColor();
        MovePipesRandomPosition();
    }

    private void MovePipesRandomPosition()
    {
        float randomDistanceBetweenPipes = Random.Range(0f, _distanceBetweenPipes);
        _topPipe.position += transform.up * randomDistanceBetweenPipes;
        _bottomPipe.position += -1f * randomDistanceBetweenPipes * transform.up;
    }

    private void SetRandomPipeColor()
    {
        int numberOfColor = _pipeColors.Length;
        if (numberOfColor <= 0)
        {
            Debug.LogWarning("Pipe Colors Not Assigned");
        }

        int colorIndex = Random.Range(0, numberOfColor);
        _topPipeSR.color = _pipeColors[colorIndex];
        _bottomPipeSR.color = _pipeColors[colorIndex];
    }

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        float deltaMove = _moveSpeed * Time.deltaTime;
        transform.position += Vector3.left * deltaMove;
    }
}
