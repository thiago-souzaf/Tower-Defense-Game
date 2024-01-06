using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private PlayerStats playerStats;
    public static BuildManager Instance { get; private set; }

    public GameObject buildEffect;

    public SelectedNodeUI nodeUI;

    [Header("Optional")]
    [Tooltip("Turret to build is a Turret Blueprint instance that is set when the user selects a turret from the shop")]
    [SerializeField] private TurretBlueprint turretToBuild;
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
            turretToBuild = value;
            DeselectNode();
        }
    }
    [Tooltip("Selected node is a Node instance that is set when the user clicks on top of a node with a turret built on")]
    [SerializeField] private Node selectedNode;
    public Node SelectedNode
    {
        get { return selectedNode;}
        set
        {

            if (selectedNode == value)
            {
                DeselectNode();
                return;
            }
            selectedNode = value;
            turretToBuild = null;

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
    public GameObject BuildTurretOn(Node node)
    {
        if (playerStats.Money < TurretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return null;
        }
        playerStats.Money -= TurretToBuild.cost;

        GameObject turret = Instantiate(TurretToBuild.prefab, node.PositionToBuild, Quaternion.identity);

        GameObject buildEffectGO = Instantiate(buildEffect, node.PositionToBuild, Quaternion.identity);

        Destroy(buildEffectGO, 2f);

        return turret;
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
