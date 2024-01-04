using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret Selected");
        buildManager.turretToBuild = buildManager.standardTurretPrefab;
    }

    public void PurchaseOtherTurret()
    {
        Debug.Log("Other turret Select");
        buildManager.turretToBuild = buildManager.anotherTurretPrefab;
    }
}
