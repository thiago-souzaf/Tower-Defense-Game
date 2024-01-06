using System;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint[] turretsToSelect;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void SelectTurret(string turretName)
    {
        Debug.Log(turretName + " was selected to build");
        TurretBlueprint turretSelected = Array.Find(turretsToSelect, turret => turret.name == turretName);
        buildManager.TurretToBuild = turretSelected;
    }

}
