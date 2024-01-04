using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemiesAlive;
    private Transform spawnPoint;
    private int wave = 1;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnInterval;

    private UIManager uiManager;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("START").transform;
        wave = 0;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        wave++;
        uiManager.UpdateWave(wave);
        for (int i = 0; i < wave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }

    public void DecrementEnemy()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            StartCoroutine(SpawnWave());
        }
    }
}
