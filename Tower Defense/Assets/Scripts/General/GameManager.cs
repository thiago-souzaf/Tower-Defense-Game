using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static bool isGameOver;

    public static bool hasGameStarted;

    public int levelToUnlock;

    public UnityEvent OnGameOver;

    public UnityEvent OnLevelComplete;

    public UnityEvent OnGameStart;

    private void Start()
    {
        isGameOver = false;
    }
    public void EndGame()
    {
        isGameOver = true;
        OnGameOver.Invoke();
        Debug.Log("Game Over");
    }

    public void WinLevel()
    {
        OnLevelComplete.Invoke();
        Debug.Log("Level Finished");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }

    public void StartGame()
    {
        hasGameStarted = true;
        OnGameStart.Invoke();
        Debug.Log("Game has started");
    }
}
