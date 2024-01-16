using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI selectedTowerName;

    [Header("Shop items")]
    public GameObject buttonsParent;
    public GameObject buttonPrefab;
    public TurretBlueprint[] turretsToSelect;

    private ShopButtonInfo[] shopButtons;

    private void Start()
    {
        shopButtons = new ShopButtonInfo[turretsToSelect.Length];
        ResetTowerName();
        for(int i = 0; i < turretsToSelect.Length; i++)
        {
            ShopButtonInfo btnToAdd = CreateButton(turretsToSelect[i]);
            shopButtons[i] = btnToAdd;
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

    private ShopButtonInfo CreateButton(TurretBlueprint turretInfo)
    {
        GameObject _btn = Instantiate(buttonPrefab, buttonsParent.transform);
        ShopButtonInfo btnInfo = _btn.GetComponent<ShopButtonInfo>();
        btnInfo.towerCost = turretInfo.buildCost;

        // Sets button onClick event to call SelectTurret
        btnInfo.button.onClick.AddListener(() => SelectionManager.Instance.SelectTurret(turretInfo));

        // Sets button image with turret sprite
        btnInfo.towerImage.sprite = turretInfo.normalTowerImage;

        // Sets turret price
        btnInfo.priceText.text = "$ " + btnInfo.towerCost;

        return btnInfo;
    }

    public void CheckIfMoneyIsEnough(int currentMoney)
    {
        foreach (ShopButtonInfo buttonInfo in shopButtons)
        {
            // button is interactable if the tower cost is less or equal to current money
            buttonInfo.button.interactable = buttonInfo.towerCost <= currentMoney;
        }
    }
}
