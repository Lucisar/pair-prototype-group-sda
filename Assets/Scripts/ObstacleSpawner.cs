using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // obstacle prefab
    [SerializeField] private GameObject obstaclePrefab;
    // spawn interval
    [SerializeField] private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        // start spawning obstacles
        StartCoroutine(SpawnObstacles());
    }

    // coroutine to spawn obstacles at intervals
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // spawn an obstacle at a random y position
            float randomY = Random.Range(-3f, 3f);
            Instantiate(obstaclePrefab, new Vector3(10f, randomY, 0f), Quaternion.identity);

            // wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}