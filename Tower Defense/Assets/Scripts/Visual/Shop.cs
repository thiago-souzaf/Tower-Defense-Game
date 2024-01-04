using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret Selected");
        buildManager.turretToBuild = standardTurret;
    }

    public void SelectOtherTurret()
    {
        Debug.Log("Other turret Select");
        buildManager.turretToBuild = anotherTurret;
    }
}
