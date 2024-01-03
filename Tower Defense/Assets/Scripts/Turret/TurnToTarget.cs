using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToTarget : MonoBehaviour
{
    public Transform partToRotate;
    private GetClosestTarget target;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<GetClosestTarget>();

    }

    // Update is called once per frame
    void Update()
    {
        if (target.target != null)
        {
            Vector3 lookPoint = new(target.target.position.x, partToRotate.position.y, target.target.position.z);
            partToRotate.LookAt(lookPoint);
        }
        
    }
}
