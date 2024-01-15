using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NodeBuilder))]
public class NodeMouseTracker : MonoBehaviour
{
    [SerializeField] private Color hoverEmptyNodeColor;
    [SerializeField] private Color hoverBuiltNodeColor;
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
        if (nodeBuilder.turret != null)
        {
            rend.material.color = hoverBuiltNodeColor;
            return;
        }
        if (selectionManager.HasTurretSelected)
        {
            selectionManager.towerPreview.transform.position = nodeBuilder.PositionToBuild;
            rend.material.color = hoverEmptyNodeColor;
            return;
        }
    }

    private void OnMouseExit()
    {
        if (selectionManager.HasTurretSelected)
        {
            selectionManager.towerPreview.transform.position = selectionManager.hiddenPosition;
        }
        rend.material.color = startColor;
    }

}
