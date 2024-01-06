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
            turretName.text = selectedNode.turret.name;
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
