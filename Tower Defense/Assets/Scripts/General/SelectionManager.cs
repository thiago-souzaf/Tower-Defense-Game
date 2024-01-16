using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }

    public SelectedNodeUI nodeUI;

    public Shop shop;

    public GameObject towerPreview;
    public Vector3 hiddenPosition = new(0, -10, 0);

    PlayerStats playerStats;

    private TurretBlueprint turretToBuild;
    public TurretBlueprint TurretToBuild
    {
        get
        {
            if (turretToBuild == null || turretToBuild.prefab == null)
            {
                return null;
            }
            return turretToBuild;
        }
        set
        {
            Destroy(towerPreview);
            turretToBuild = value;
            // Deselect node when player select a tower on shop
            DeselectNode();
        }
    }
    private NodeBuilder selectedNode;
    public NodeBuilder SelectedNode
    {
        get { return selectedNode;}
        set
        {

            if (selectedNode == value)
            {
                // Deselect node when player clicks on node again
                DeselectNode();
                return;
            }
            DeselectNode();
            selectedNode = value;
            if (selectedNode.turret.TryGetComponent(out RangeShow range))
            { range.ShowRangeIndicator(true); }
            DeselectTurret();
            nodeUI.SelectedNode = selectedNode;
        }
    }

    public bool HasTurretSelected {  get { return TurretToBuild != null; }  }

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

    public void SelectTurret(TurretBlueprint turretBlueprintToBuild)
    {
        if (playerStats.Money < turretBlueprintToBuild.buildCost)
        {
            Debug.Log("Not enough money");
            DeselectTurret();
            return;
        }
        Debug.Log(turretBlueprintToBuild.name + " was selected to build");
        TurretToBuild = turretBlueprintToBuild;
        shop.SetTowerName(turretBlueprintToBuild.name);
        
        // Create a preview of the tower selected
        towerPreview = Instantiate(turretBlueprintToBuild.prefab, hiddenPosition, Quaternion.identity);
        foreach (MonoBehaviour c in towerPreview.GetComponents<MonoBehaviour>())
        {
            c.enabled = false;
        }
    }


    public void DeselectNode()
    {
        if (selectedNode == null)
        {
            return;
        }

        if (selectedNode.turret && selectedNode.turret.TryGetComponent(out RangeShow range))
        { range.ShowRangeIndicator(false); }
        selectedNode = null;
        nodeUI.Hide();
    }

    private void DeselectTurret()
    {
        turretToBuild = null;
        shop.ResetTowerName();
        Destroy(towerPreview);
    }
}
