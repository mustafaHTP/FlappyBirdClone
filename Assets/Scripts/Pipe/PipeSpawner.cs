using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _timeBetweenPipes;
    [SerializeField] private float _pipeSpawnPositionYOffset;

    private IEnumerator SpawnPipe()
    {
        while (true)
        {
            Vector2 pipeSpawnPosition = transform.position;
            pipeSpawnPosition.y += Random.Range(-1f * _pipeSpawnPositionYOffset, _pipeSpawnPositionYOffset);

            Instantiate(_pipePrefab, pipeSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_timeBetweenPipes);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnPipe());
    }
}
