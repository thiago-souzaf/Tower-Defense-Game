using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveNumberTxt;
    public TextMeshProUGUI moneyTxt;

    public void UpdateWave(int currentWave)
    {
        waveNumberTxt.text = currentWave.ToString();
    }

    public void UpdateMoney(int currentMoney)
    {
        moneyTxt.text = "M $" + currentMoney;
    }
}
