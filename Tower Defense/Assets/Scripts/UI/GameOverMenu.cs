using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public PlayerStats playerStats;

    public SceneFader sceneFader;

    public readonly string homeSceneName = "MainMenu";
    private void OnEnable()
    {
        roundsText.text = playerStats.CurrentRound.ToString();
        Time.timeScale = 0f;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(homeSceneName);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
}
