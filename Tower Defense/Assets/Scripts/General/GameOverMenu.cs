using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public PlayerStats playerStats;

    public readonly string homeSceneName = "MainMenu";
    private void OnEnable()
    {
        roundsText.text = playerStats.Round.ToString();
    }

    public void Home()
    {
        SceneManager.LoadScene(homeSceneName);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
