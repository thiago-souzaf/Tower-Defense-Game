using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private UIManager uiManager;
    private int money;
    public int Money
    {
        get { return money; }
        set { money = value; uiManager.UpdateMoney(money); }
    }
    public int startMoney = 400;
    void Start()
    {
        uiManager = GetComponent<UIManager>();
        Money = startMoney;
    }
}
