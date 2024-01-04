using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private Vector3 positionOffset = new(0, 0.5f);
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Já tem uma torre aqui!!");
            return;
        }

        GameObject turretToBuild = BuildManager.Instance.turretToBuild;
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
