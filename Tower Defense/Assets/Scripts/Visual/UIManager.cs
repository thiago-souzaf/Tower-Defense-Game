using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI roundNumberTxt;
    public TextMeshProUGUI moneyTxt;
    public TextMeshProUGUI livesTxt;

    public GameObject gameOverScreen;
    public void UpdateRound(int currentRound)
    {
        roundNumberTxt.text = currentRound.ToString();
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
        gameOverScreen.SetActive(true);
    }
}
