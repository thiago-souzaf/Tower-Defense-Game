using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    private EnemyHealth enemyHealth;

    private PlayerStats playerStats;
    void Start()
    {
        target = Waypoints.points[0];
        enemyHealth = GetComponent<EnemyHealth>();
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        transform.LookAt(target.position);
        transform.Translate(speed * Time.deltaTime * transform.forward, Space.World);

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
