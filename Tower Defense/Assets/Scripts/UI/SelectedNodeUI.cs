using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedNodeUI : MonoBehaviour
{
    public GameObject ui;
    public TextMeshProUGUI turretName;

    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;

    public TextMeshProUGUI sellCost;
    

    private NodeBuilder selectedNode;
    public NodeBuilder SelectedNode
    {
        set
        {
            selectedNode = value;
            ui.SetActive(true);
            turretName.text = GetTurretName(selectedNode);
            SetUpgradePrice(selectedNode.isUpgraded);
            SetSellCost(selectedNode);
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    private string GetTurretName(NodeBuilder node)
    {
        if (node.turret.TryGetComponent(out Turret turretStats))
        {
            return turretStats.info.name;
        }
        return "[name not found]";
    }

    private void SetUpgradePrice(bool isUpgraded)
    {
        if (isUpgraded)
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeCost.text = "$ " + selectedNode.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
    }

    private void SetSellCost(NodeBuilder node)
    {
        sellCost.text = "$ " + node.turretBlueprint.SellAmount;
    }

    public void Upgrade()
    {
        if (selectedNode != null)
        {
            selectedNode.UpgradeTurret();
            SelectionManager.Instance.DeselectNode();
        }
    }

    public void Sell()
    {
        if (selectedNode != null)
        {
            selectedNode.SellTurret();
            SelectionManager.Instance.DeselectNode();
        }
    }
}
