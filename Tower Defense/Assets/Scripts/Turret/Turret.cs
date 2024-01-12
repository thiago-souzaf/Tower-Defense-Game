using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Target Selection")]
    [HideInInspector]
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";

    [Header("Animate tower body")]
    public Animator towerAnimator;

}
