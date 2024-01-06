using System;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint[] turretsToSelect;

    SelectionManager selectionManager;

    private void Start()
    {
        selectionManager = SelectionManager.Instance;
    }

    public void SelectTurret(string turretName)
    {
        Debug.Log(turretName + " was selected to build");
        TurretBlueprint turretSelected = Array.Find(turretsToSelect, turret => turret.name == turretName);
        selectionManager.TurretToBuild = turretSelected;
    }

}
