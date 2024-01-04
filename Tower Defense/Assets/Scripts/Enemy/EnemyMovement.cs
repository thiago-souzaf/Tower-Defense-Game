using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    private EnemyHealth enemyHealth;
    void Start()
    {
        target = Waypoints.points[0];
        enemyHealth = GetComponent<EnemyHealth>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            enemyHealth.Die();
            Debug.Log("Chegou ao final");
        }
    }
}
