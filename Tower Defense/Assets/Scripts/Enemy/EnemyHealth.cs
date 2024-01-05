using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int fullHealth = 10;
    public int Health {  get; private set; }

    [Tooltip("Money the player will get when this enemy dies")]
    public int value = 50;

    private EnemySpawner spawner;
    private PlayerStats playerStats;

    private EnemyVFX vfx;

    private void Start()
    {
        Health = fullHealth;
        GameObject gameManager = GameObject.Find("GameManager");
        spawner = gameManager.GetComponent<EnemySpawner>();
        playerStats = gameManager.GetComponent<PlayerStats>();
        vfx = GetComponent<EnemyVFX>();
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        spawner.DecrementEnemy();
        Destroy(gameObject);
        playerStats.Money += value;
        vfx.OnDeath();
    }
}
