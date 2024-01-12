using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedNodeUI : MonoBehaviour
{
    public GameObject ui;
    public TextMeshProUGUI turretName;
    public Image towerImage;
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

            // Set info on UI
            SetTurretName(selectedNode);
            SetTurretImage(selectedNode);
            SetUpgradePrice(selectedNode);
            SetSellPrice(selectedNode);
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    private void SetTurretName(NodeBuilder node)
    {
        if (node.turretBlueprint != null)
        {
            turretName.text = node.turretBlueprint.name;
            return;
        }
        turretName.text = "[name not found]";
    }

    private void SetTurretImage(NodeBuilder node)
    {
        towerImage.sprite = node.turretBlueprint.imageSprite;
    }

    private void SetUpgradePrice(NodeBuilder node)
    {
        if (node.isUpgraded)
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

    private void SetSellPrice(NodeBuilder node)
    {
        sellCost.text = "$ " + node.turretBlueprint.SellPrice;
    }

    public void Upgrade()
    {
        if (selectedNode != null)
        {
            selectedNode.UpgradeTurret();
            SetUpgradePrice(selectedNode);
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
