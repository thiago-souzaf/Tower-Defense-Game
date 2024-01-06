using TMPro;
using UnityEngine;

public class SelectedNodeUI : MonoBehaviour
{
    public GameObject ui;
    public TextMeshProUGUI turretName;
    

    private Node selectedNode;
    public Node SelectedNode
    {
        set
        {
            selectedNode = value;
            ui.SetActive(true);
            turretName.text = GetTurretName(selectedNode);
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
}
