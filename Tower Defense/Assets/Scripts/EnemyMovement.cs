using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
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
            Destroy(gameObject);
            Debug.Log("Chegou ao final");
        }
    }
}
