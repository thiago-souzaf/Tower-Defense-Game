using System.Collections;
using UnityEngine;
[RequireComponent (typeof(Turret))]
public class Shooting : MonoBehaviour
{

    private Turret turret;

    private float nextTimeToShoot;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turret.target != null && Time.time >= nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1f/turret.currentFireRate;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        turret.towerAnimator.SetTrigger("shoot");
        yield return new WaitForSeconds(turret.animationTimeToShoot); // Time until the animation is on correct position to shoot
        GameObject bulletGO = Instantiate(turret.bulletPrefab, turret.bulletSpawnPoint.position, turret.bulletSpawnPoint.rotation);

        if(bulletGO.TryGetComponent(out Bullet bullet))
        {
            bullet.SetDirection(turret.bulletSpawnPoint.forward, turret.currentRange);
        }
    }
}
