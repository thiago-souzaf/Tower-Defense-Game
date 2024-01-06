using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    private Vector3 positionOffset = new(0, 0.5f);

    public Vector3 PositionToBuild {  get { return transform.position + positionOffset; } }

    BuildManager buildManager;
    PlayerStats playerStats;


    void Start()
    {
        buildManager = BuildManager.Instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        playerStats = buildManager.GetComponent<PlayerStats>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        
        if (turret != null) // If there is a turret on top of this node
        {
            buildManager.SelectedNode = this;
            return;
        }
        if (!buildManager.HasTurretSelected) // If the user hasn't selected a turret from the shop
        {
            Debug.Log("Select a turret");
            return;
        }
        BuildTurret(buildManager.TurretToBuild);
         
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (playerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        playerStats.Money -= blueprint.cost;

        GameObject _turret = Instantiate(blueprint.prefab, PositionToBuild, Quaternion.identity);
        _turret.GetComponent<Turret>().info = blueprint;
        this.turret = _turret;

        // Visual Effects
        GameObject buildEffectGO = Instantiate(buildManager.buildEffect, PositionToBuild, Quaternion.identity);
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
        _turret.GetComponent<Turret>().info = turretBlueprint;
        this.turret = _turret;

        // Visual Effects
        GameObject buildEffectGO = Instantiate(buildManager.buildEffect, PositionToBuild, Quaternion.identity);
        Destroy(buildEffectGO, 2f);

        isUpgraded = true;
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.HasTurretSelected)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
