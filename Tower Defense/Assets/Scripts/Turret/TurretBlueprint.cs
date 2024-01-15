using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    [Header("Tower info")]
    public string name;
    [Tooltip("Image used on shop button and when a node with this tower is selected")]
    public Sprite normalTowerImage;
    [Tooltip("Image used when a node with this tower is selected")]
    public Sprite upgradedTowerImage;

    [Header("Basic version")]
    public GameObject prefab;
    public int buildCost;

    [Header("Upgraded version")]
    public GameObject upgradedPrefab;
    public int upgradeCost;

    // Sell price
    public int SellPrice { get { return buildCost / 2; } }
}
