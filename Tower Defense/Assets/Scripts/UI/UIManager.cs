using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI roundNumberTxt;
    public TextMeshProUGUI moneyTxt;
    public TextMeshProUGUI livesTxt;

    public GameObject gameOverMenu;
    public void UpdateRound(int currentRound, int lastRound)
    {
        roundNumberTxt.text = currentRound + "/" + lastRound;
    }

    public void UpdateMoney(int currentMoney)
    {
        moneyTxt.text = "M $" + currentMoney;
    }

    public void UpdateLives(int currentLives)
    {
        livesTxt.text = "L " + currentLives;
    }

    public void OnGameOver()
    {
        gameOverMenu.SetActive(true);
    }
}
