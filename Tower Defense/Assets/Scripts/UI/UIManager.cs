using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Player status TMP")]
    public TextMeshProUGUI roundNumberTxt;
    public TextMeshProUGUI moneyTxt;
    public TextMeshProUGUI livesTxt;

    [Header("Game Over Menu")]
    public GameObject gameOverMenuUI;
    public TextMeshProUGUI gameOverRoundsText;

    [Space]
    public GameObject pauseMenu;
    public GameObject victoryMenu;

    [Header("Scene Transition")]
    public string homeSceneName = "MainMenu";
    public SceneFader sceneFader;

    private float normalTime;
    private void Start()
    {
        gameOverMenuUI.SetActive(false);
        pauseMenu.SetActive(false);
        victoryMenu.SetActive(false);
    }

    #region Player Status Update on UI
    public void UpdateRound(int currentRound, int lastRound)
    {
        roundNumberTxt.text = currentRound + "/" + lastRound;
    }

    public void UpdateMoney(int currentMoney)
    {
        moneyTxt.text = "$" + currentMoney;
    }

    public void UpdateLives(int currentLives)
    {
        livesTxt.text = currentLives.ToString();
    }
    #endregion

    #region Game Over Menu Methods
    public void ShowGameOver()
    {
        gameOverMenuUI.SetActive(true);
        gameOverRoundsText.text = roundNumberTxt.text;
        StopTime(true);
    }
    #endregion

    #region Victory Menu Methods
    public void ShowVictoryMenu()
    {
        victoryMenu.SetActive(true);
        StopTime(true);
    }
    #endregion

    #region Pause Menu Methods
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            StopTime(true);
        }
        else
        {
            StopTime(false);
        }

        AudioManager.Instance.PlaySoundFX(AudioManager.Instance.togglePause);
    }
    #endregion

    public void Home()
    {
        Time.timeScale = 1.0f;
        sceneFader.FadeTo(homeSceneName);
    }

    public void Retry()
    {
        StopTime(false);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    private void StopTime(bool stop)
    {
        if (stop)
        {
            normalTime = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = normalTime;
        }
    }
}
