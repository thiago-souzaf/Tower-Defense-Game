using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Target Selection")]
    [HideInInspector]
    public Transform target;
    public float startRange = 15f;
    public float currentRange;
    public string enemyTag = "Enemy";

    [Header("Shooting")]
    public float startFireRate = 1f;
    public float currentFireRate;
    [Tooltip("Seconds until the animation is on correct position to shoot")]
    [Range(0f, 1f)]
    public float animationTimeToShoot = 0.167f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    [Header("Rotate Head")]
    public Transform partToRotate;

    [Header("Animate tower body")]
    public Animator towerAnimator;

    [HideInInspector]
    public TurretBlueprint info;

    private void Start()
    {
        currentRange = startRange;
        currentFireRate = startFireRate;
    }
}
