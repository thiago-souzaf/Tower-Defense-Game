using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private Vector3 positionOffset = new(0, 0.5f);

    public Vector3 PositionToBuild {  get { return transform.position + positionOffset; } }

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.Instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.HasTurretSelected)
        {
            Debug.Log("Select a turret");
            return;
        }
        if (turret != null)
        {
            Debug.Log("This node already has a turret on");
            return;
        }
        turret = buildManager.BuildTurretOn(this);
         
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.HasTurretSelected)
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
