using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    [SerializeField] GameObject deathEffects;

    public void OnDeath()
    {
        GameObject deathFX = Instantiate(deathEffects, transform.position, Quaternion.identity);

        Destroy(deathFX, 2f);
    }
}
