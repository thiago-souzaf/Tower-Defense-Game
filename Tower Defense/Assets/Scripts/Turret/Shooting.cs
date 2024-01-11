using System.Collections;
using UnityEngine;
[RequireComponent (typeof(Turret))]
public class Shooting : MonoBehaviour
{
    public bool isAttacker;

    public float fireRate = 1f;
    [Tooltip("Seconds until the animation is on correct position to shoot")]
    [Range(0f, 1f)]
    public float animationTimeToShoot = 0.167f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private Turret turret;

    private float nextTimeToShoot;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponent<Turret>();
        nextTimeToShoot = Time.time + 1f / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if ((turret.target != null || !isAttacker) && Time.time >= nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1f/fireRate;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        turret.towerAnimator.SetTrigger("shoot");
        yield return new WaitForSeconds(animationTimeToShoot); // Time until the animation is on correct position to shoot
        GameObject bulletGO = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        if(bulletGO.TryGetComponent(out Bullet bullet))
        {
            bullet.SetDirection(bulletSpawnPoint.forward, turret.range);
        }
    }
}
