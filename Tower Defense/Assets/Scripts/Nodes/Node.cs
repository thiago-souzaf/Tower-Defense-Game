using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private Vector3 positionOffset = new(0, 0.5f);

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

        if (buildManager.turretToBuild == null)
        {
            Debug.Log("Select a turret");
            return;
        }
        if (turret != null)
        {
            Debug.Log("Já tem uma torre aqui!!");
            return;
        }

        GameObject turretToBuild = buildManager.turretToBuild;
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
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
