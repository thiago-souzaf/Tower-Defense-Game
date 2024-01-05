using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public PlayerStats playerStats;

    private void OnEnable()
    {
        roundsText.text = playerStats.Round.ToString();
    }

    public void Home()
    {
        Debug.LogError("Need implementation of home scene");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
