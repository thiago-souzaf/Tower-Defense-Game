using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    private EnemyHealth enemyHealth;

    private PlayerStats playerStats;

    public Transform enemyBody;
    void Start()
    {
        target = Waypoints.points[0];
        enemyHealth = GetComponent<EnemyHealth>();
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        // Rotates the enemy body to look at the next target
        enemyBody.LookAt(target.position);

        Vector3 dirToTarget = (target.position - transform.position).normalized;
        transform.Translate(speed * Time.deltaTime * dirToTarget, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void EndPath()
    {
        enemyHealth.Die();
        playerStats.Lives--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            EndPath();
        }
    }


}
