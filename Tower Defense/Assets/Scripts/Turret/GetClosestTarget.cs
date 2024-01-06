using UnityEngine;

[RequireComponent (typeof(Turret))]
public class GetClosestTarget : MonoBehaviour
{
    private Turret turret;
    void Start()
    {
        turret = GetComponent<Turret>();
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);

    }
    
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(turret.enemyTag);

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

        if (closestEnemy != null && shortestDistance <= turret.range)
        {
            turret.target = closestEnemy.transform;
        } else
        {
            turret.target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turret.range);
    }
}
