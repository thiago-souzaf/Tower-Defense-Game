using UnityEngine;

public class NodeBuilder : MonoBehaviour
{
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    PlayerStats playerStats;

    private Vector3 positionOffset = new(0, 0.5f);

    public Vector3 PositionToBuild { get { return transform.position + positionOffset; } }

    public GameObject buildEffect;
    public GameObject upgradeEffect;
    public GameObject sellEffect;

    private void Start()
    {
        playerStats = SelectionManager.Instance.GetComponent<PlayerStats>();
    }

    public void BuildTurret(TurretBlueprint blueprint)
    {
        if (playerStats.Money < blueprint.buildCost)
        {
            Debug.Log("Not enough money");
            return;
        }
        playerStats.Money -= blueprint.buildCost;

        GameObject _turret = Instantiate(blueprint.prefab, PositionToBuild, Quaternion.identity);
        this.turret = _turret;

        // Visual Effects
        GameObject buildEffectGO = Instantiate(buildEffect, PositionToBuild, Quaternion.identity);
        Destroy(buildEffectGO, 2f);

        turretBlueprint = blueprint;
    }

    public void UpgradeTurret()
    {
        if (playerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money");
            return;
        }
        playerStats.Money -= turretBlueprint.upgradeCost;

        // Destroy the old turret
        Destroy(turret);

        // Build a new turret
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, PositionToBuild, Quaternion.identity);
        this.turret = _turret;

        // Visual Effects
        GameObject buildEffectGO = Instantiate(upgradeEffect, PositionToBuild, Quaternion.identity);
        Destroy(buildEffectGO, 2f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        playerStats.Money += turretBlueprint.SellPrice;

        DeleteTurret();

        // Visual Effects
        GameObject buildEffectGO = Instantiate(sellEffect, PositionToBuild, Quaternion.identity);
        Destroy(buildEffectGO, 2f);
    }

    private void DeleteTurret()
    {
        Destroy(turret);
        turret = null;
        turretBlueprint = null;
        isUpgraded = false;
    }
}
