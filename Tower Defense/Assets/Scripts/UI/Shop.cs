using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI selectedTowerName;

    [Header("Shop items")]
    public GameObject buttonsParent;
    public GameObject buttonPrefab;
    public TurretBlueprint[] turretsToSelect;
    

    private void Start()
    {
        ResetTowerName();
        foreach(TurretBlueprint turret in turretsToSelect)
        {
            CreateButton(turret);
        }
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

    private void CreateButton(TurretBlueprint turretInfo)
    {
        GameObject _btn = Instantiate(buttonPrefab, buttonsParent.transform);

        // Sets button onClick event to call SelectTurret
        _btn.GetComponent<Button>().onClick.AddListener(() => SelectionManager.Instance.SelectTurret(turretInfo));

        // Sets button image with turret sprite
        _btn.GetComponentsInChildren<Image>()[1].sprite = turretInfo.imageSprite;

        // Sets turret price
        _btn.GetComponentInChildren<TextMeshProUGUI>().text = "$ " + turretInfo.buildCost;

    }
}
