using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    [SerializeField] GameObject deathEffects;
    [SerializeField] Material enemyMaterial;

    public void OnDeath()
    {
        deathEffects.GetComponentInChildren<ParticleSystemRenderer>().material = enemyMaterial;
        GameObject deathFX = Instantiate(deathEffects, transform.position, Quaternion.identity);

        Destroy(deathFX, 2f);
    }
}
