using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveNumberTxt;
    public TextMeshProUGUI moneyTxt;
    public TextMeshProUGUI livesTxt;

    public void UpdateWave(int currentWave)
    {
        waveNumberTxt.text = currentWave.ToString();
    }

    public void UpdateMoney(int currentMoney)
    {
        moneyTxt.text = "M $" + currentMoney;
    }

    public void UpdateLives(int currentLives)
    {
        livesTxt.text = "L " + currentLives;
    }
}
