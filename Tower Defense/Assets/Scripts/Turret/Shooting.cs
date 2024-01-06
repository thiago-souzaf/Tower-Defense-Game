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
            nextTimeToShoot = Time.time + 1f/turret.fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log(transform.name + " is Shooting!");

        GameObject bulletGO = Instantiate(turret.bulletPrefab, turret.bulletSpawnPoint.position, turret.bulletSpawnPoint.rotation);

        if(bulletGO.TryGetComponent(out Bullet bullet))
        {
            bullet.Seek(turret.target);
        }
    }
}
