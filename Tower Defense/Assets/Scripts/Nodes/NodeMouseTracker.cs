using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NodeBuilder))]
public class NodeMouseTracker : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    private Renderer rend;
    private Color startColor;

    SelectionManager selectionManager;

    NodeBuilder nodeBuilder;

    void Start()
    {
        selectionManager = SelectionManager.Instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        nodeBuilder = GetComponent<NodeBuilder>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (nodeBuilder.turret != null) // If there is a turret on top of this node
        {
            selectionManager.SelectedNode = nodeBuilder;
            return;
        }
        if (!selectionManager.HasTurretSelected) // If the user hasn't selected a turret from the shop
        {
            return;
        }
        nodeBuilder.BuildTurret(selectionManager.TurretToBuild);
         
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!selectionManager.HasTurretSelected)
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
