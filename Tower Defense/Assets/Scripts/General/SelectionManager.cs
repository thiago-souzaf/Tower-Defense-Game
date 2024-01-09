using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }

    public SelectedNodeUI nodeUI;

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
            turretToBuild = value;
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
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
