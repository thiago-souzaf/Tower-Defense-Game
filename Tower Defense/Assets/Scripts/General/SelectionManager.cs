using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }

    public SelectedNodeUI nodeUI;

    public Shop shop;

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
            selectedNode = value;
            turretToBuild = null;
            shop.ResetTowerName();
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

    public void SelectTurret(TurretBlueprint turretBlueprintToBuild)
    {
        Debug.Log(turretBlueprintToBuild.name + " was selected to build");
        TurretToBuild = turretBlueprintToBuild;
        shop.SetTowerName(turretBlueprintToBuild.name);
    }


    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
        
    }
}
