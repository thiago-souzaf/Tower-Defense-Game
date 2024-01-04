using UnityEngine;

public class Shooting : MonoBehaviour
{

    private GetClosestTarget target;

    public float fireRate;

    private float nextTimeToShoot;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<GetClosestTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.target != null && Time.time >= nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log(transform.name + " is Shooting!");

        GameObject bulletGO = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        if(bulletGO.TryGetComponent(out Bullet bullet))
        {
            bullet.Seek(target.target);
        }
    }
}
