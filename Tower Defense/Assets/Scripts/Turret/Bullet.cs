using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string EnemyTag = "Enemy";

    private Vector3 shootingDir;

    private Vector3 initPos;

    public float bulletSpeed = 10f;

    public float maxRange;

    public int bulletDamage = 5;


    private void Start()
    {
        initPos = transform.position;
    }

    public void SetDirection(Vector3 dir, float range)
    {
        shootingDir = dir.normalized;
        maxRange = range * 1.25f;
    }

    void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * shootingDir, Space.World);

        if(Vector3.Distance(initPos, transform.position) > maxRange)
        {
            Destroy(gameObject);
        }

    }

    private void HitTarget(GameObject enemyHit)
    {
        if( enemyHit.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyTag))
        {
            HitTarget(other.gameObject);
        }
    }
}
