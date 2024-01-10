using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI selectedTowerName;

    [Header("Shop items")]
    public TurretBlueprint[] turretsToSelect;

    private void Start()
    {
        ResetTowerName();
    }

    public void SetTowerName(string towerName)
    {
        selectedTowerName.text = towerName;
        selectedTowerName.color = new Color(1, 1, 1, 1);
    }

    public void ResetTowerName()
    {
        selectedTowerName.text = "Select a tower";
        selectedTowerName.color = new Color(1, 1, 1, 0.3f);
    }
}
