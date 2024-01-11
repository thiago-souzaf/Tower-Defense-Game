using UnityEngine;

[RequireComponent (typeof(Turret))]
public class TurnToTarget : MonoBehaviour
{
    public Transform partToRotate;

    private Turret turret;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turret.target != null)
        {
            Vector3 lookPoint = new(turret.target.position.x, partToRotate.position.y, turret.target.position.z);
            partToRotate.LookAt(lookPoint);
        }
    }
}
