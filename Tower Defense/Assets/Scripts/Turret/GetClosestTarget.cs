using UnityEngine;

[RequireComponent (typeof(Turret))]
public class GetClosestTarget : MonoBehaviour
{
    private Turret turret;
    void Start()
    {
        turret = GetComponent<Turret>();
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.3f);
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

        if (closestEnemy != null && shortestDistance <= turret.currentRange)
        {
            turret.target = closestEnemy.transform;
        } else
        {
            turret.target = null;
        }
    }

    // Draw the turret range on editor view
    private void OnDrawGizmosSelected()
    {
        // if it isn't on play mode, it will not get the turret component and will not show the correct range for each turret
        float radius;
        if (turret != null)
        {
            radius = turret.currentRange;
        } else
        {
            radius = 15f;
        }
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
