using UnityEngine;

[System.Serializable]
public class Wave
{
	public EnemyCounter[] enemiesToSpawn;
    public float rateToSpawn;
}

[System.Serializable]
public class EnemyCounter
{
	public GameObject enemyPrefab;
	public int amountToSpawn;
}
