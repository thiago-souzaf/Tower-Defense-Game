using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int enemiesAlive;
    public int EnemiesAlive
    {
        get { return enemiesAlive; }
        set
        {
            enemiesAlive = value;
            if (enemiesAlive <= 0 && hasSpawnedAll)
            {
                StartCoroutine(SpawnWave());
            }
        }
    }

    private Transform spawnPoint;

    public Wave[] waves;

    private int waveIndex;

    private int amountOfWaves;

    private PlayerStats playerStats;
    private GameManager manager;

    private bool hasSpawnedAll;


    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        manager = GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("START").transform;
        waveIndex = 0;
        amountOfWaves = waves.Length;
        playerStats.lastRound = amountOfWaves;
        StartCoroutine(SpawnWave());

    }

    IEnumerator SpawnWave()
    {

        if (waveIndex >= waves.Length)
        {
            // Waves finished
            // TODO: implement "level complete" screen
            manager.WinLevel();
            this.enabled = false;
            yield break;
        }

        Wave curretWave = waves[waveIndex];
        hasSpawnedAll = false;
        playerStats.CurrentRound = waveIndex + 1;

        foreach (EnemyCounter enemyCounter in curretWave.enemiesToSpawn)
        {
            for (int i = 0; i < enemyCounter.amountToSpawn; i++)
            {
                yield return new WaitForSeconds(1f/ curretWave.rateToSpawn);
                SpawnEnemy(enemyCounter.enemyPrefab);
            }
        }
        hasSpawnedAll = true;
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemyToSpawn)
    {
        Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
        enemiesAlive++;
    }

}
