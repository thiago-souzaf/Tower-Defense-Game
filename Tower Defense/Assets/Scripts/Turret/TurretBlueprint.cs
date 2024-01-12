using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    [Header("Tower info")]
    public string name;
    public Sprite imageSprite;

    [Header("Basic version")]
    public GameObject prefab;
    public int buildCost;

    [Header("Upgraded version")]
    public GameObject upgradedPrefab;
    public int upgradeCost;

    // Sell price
    public int SellPrice { get { return buildCost / 2; } }
}
