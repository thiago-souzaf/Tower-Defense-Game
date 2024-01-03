using System.Collections;
using UnityEngine;

public class GetClosestTarget : MonoBehaviour
{

    public Transform target;
    public float range = 15f;


    public string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);

    }
    
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortestDistance <= range)
        {
            target = closestEnemy.transform;
        } else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
