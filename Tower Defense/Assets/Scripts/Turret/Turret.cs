using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Target Selection")]
    public Transform target;

    public float startRange = 15f;
    public float range;

    public string enemyTag = "Enemy";

    [Header("Shooting")]
    public float startFireRate = 1f;
    public float fireRate;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    [Header("Rotate Head")]
    public Transform partToRotate;

    [Header("Turret Info - Auto filled when instatiated")]
    public TurretBlueprint info;

    private void Start()
    {
        range = startRange;
        fireRate = startFireRate;
    }
}
