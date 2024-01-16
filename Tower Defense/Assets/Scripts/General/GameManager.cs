using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static bool isGameOver;

    public static bool isWaveOn;

    public static bool autoStart;

    public int levelToUnlock;

    public UnityEvent OnGameOver;

    public UnityEvent OnLevelComplete;

    public UnityEvent OnGameStart;

    private bool isGameFast;

    private void Start()
    {
        isGameOver = false;
        autoStart = false;
        isGameFast = Time.timeScale > 1.5f;
        isWaveOn = false;
    }
    public void EndGame()
    {
        isGameOver = true;
        OnGameOver.Invoke();
        Debug.Log("Game Over");
        AudioManager.Instance.PlaySoundFX(AudioManager.Instance.loseLevel);
    }

    public void WinLevel()
    {
        OnLevelComplete.Invoke();
        Debug.Log("Level Finished");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        AudioManager.Instance.PlaySoundFX(AudioManager.Instance.winLevel);
    }

    public void StartGame()
    {
        isWaveOn = true;
        OnGameStart.Invoke();
        Debug.Log("Game has started");
        AudioManager.Instance.PlaySoundFX(AudioManager.Instance.startRound);
    }

    public void SetAutoStart(bool value)
    {
        autoStart = value;
    }

    public void ToggleGameTimeScale()
    {
        Time.timeScale = isGameFast ? 1 : 2;
        isGameFast = !isGameFast;
    }

    // TODO: Make the turtle regenerate life after a certain amount of time
}
