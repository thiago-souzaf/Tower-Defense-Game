using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public Transform endPoint; 
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        endPoint = GameObject.Find("END").transform;

        enemyAgent.SetDestination(endPoint.position);
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
