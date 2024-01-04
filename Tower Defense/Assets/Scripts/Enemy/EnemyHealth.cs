using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int fullHealth = 10;
    public int health {  get; private set; }

    private EnemySpawner spawner;

    private void Start()
    {
        health = fullHealth;
        spawner = GameObject.Find("GameManager").GetComponent<EnemySpawner>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        spawner.DecrementEnemy();
        Destroy(gameObject);
    }
}
