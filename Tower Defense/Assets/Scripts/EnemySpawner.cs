using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform spawnPoint;
    private int wave = 5;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("START").transform;

        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < wave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
