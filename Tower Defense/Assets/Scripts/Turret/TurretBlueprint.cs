using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public string name;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;
}
