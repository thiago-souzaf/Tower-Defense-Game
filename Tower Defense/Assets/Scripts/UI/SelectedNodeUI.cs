using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedNodeUI : MonoBehaviour
{
    public GameObject ui;
    public TextMeshProUGUI turretName;
    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;
    

    private Node selectedNode;
    public Node SelectedNode
    {
        set
        {
            selectedNode = value;
            ui.SetActive(true);
            turretName.text = GetTurretName(selectedNode);
            if (selectedNode.isUpgraded)
            {
                upgradeCost.text = "MAX";
                upgradeButton.interactable = false;
            } else
            {
                upgradeCost.text = "$ " + selectedNode.turretBlueprint.upgradeCost;
                upgradeButton.interactable = true;
            }
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public string GetTurretName(Node node)
    {
        if (node.turret.TryGetComponent(out Turret turretStats))
        {
            return turretStats.info.name;
        }
        return "[name not found]";
    }

    public void Upgrade()
    {
        if (selectedNode != null)
        {
            selectedNode.UpgradeTurret();
            BuildManager.Instance.DeselectNode();
        }
    }
}
