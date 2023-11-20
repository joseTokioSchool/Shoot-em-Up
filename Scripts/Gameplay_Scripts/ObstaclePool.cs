using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 4;

    [Header("Spawn Time")]
    [SerializeField] private float minRandom;
    [SerializeField] private float MaxRandom;
    private float spawnTime;

    [Header("Positions")]
    [SerializeField] private float minXPosition = -8.3f;
    [SerializeField] private float maxXPosition = 8.3f;
    [SerializeField] private float ySpawnPosition;

    private float timeElapsed;
    private int obstacleCount;
    private GameObject[] obstacle;
    void Start()
    {
        obstacle = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            obstacle[i] = Instantiate(obstaclePrefab);
            obstacle[i].SetActive(false);
        }

        spawnTime = 0.75f;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnTime)
        {
            SpawnObstacle();
        }
    }
    private void SpawnObstacle()
    {
        spawnTime = Random.Range(minRandom, MaxRandom);
        timeElapsed = 0f;

        float xSpawnPosition = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(xSpawnPosition, ySpawnPosition, 0);
        obstacle[obstacleCount].transform.position = spawnPosition;

        if (!obstacle[obstacleCount].activeSelf)
        {
            obstacle[obstacleCount].SetActive(true);
        }

        obstacleCount++;

        if (obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }

    }
}
