using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string EnemyTag = "Enemy";
    private Transform target;
    private Vector3 shootingDir;

    private Vector3 initPos;

    public float bulletSpeed = 10f;

    public float maxRange = 20f;


    private void Start()
    {
        initPos = transform.position;
    }

    public void Seek(Transform _target)
    {
        target = _target;
        shootingDir = target.position - transform.position;
        shootingDir.Normalize();
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
        Destroy(enemyHit);
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
