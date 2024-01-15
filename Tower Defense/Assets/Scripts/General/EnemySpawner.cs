using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{

    public UnityEvent OnWaveComplete;
    private int enemiesAlive;
    public int EnemiesAlive
    {
        get { return enemiesAlive; }
        set
        {
            enemiesAlive = value;
            if (enemiesAlive <= 0 && hasSpawnedAll) // if wave completed
            {
                if (waveIndex >= waves.Length) // if level completed
                {
                    manager.WinLevel();
                    this.enabled = false;
                    return;
                }

                if (GameManager.autoStart)
                {
                    StartWave();
                } else
                {
                    OnWaveComplete.Invoke();
                    GameManager.isWaveOn = false;
                }
                playerStats.IncrementMoney(100 + waveIndex);
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

    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {

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
