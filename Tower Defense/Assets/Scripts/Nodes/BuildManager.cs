using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private PlayerStats playerStats;
    public static BuildManager Instance { get; private set; }

    public GameObject buildEffect;

    [Header("Optional")]
    [Tooltip("Turret to build is a Turret Blueprint instance that is set when the user selects a turret from the shop")]
    public TurretBlueprint turretToBuild;

    public bool HasTurretSelected {  get { return turretToBuild.prefab != null; }  }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than 1 instance of build manager.");
            return;
        }
        Instance = this;
        
    }

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    public GameObject BuildTurretOn(Node node)
    {
        if (playerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return null;
        }
        playerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.PositionToBuild, Quaternion.identity);

        GameObject buildEffectGO = Instantiate(buildEffect, node.PositionToBuild, Quaternion.identity);

        Destroy(buildEffectGO, 2f);

        return turret;
    }
}
