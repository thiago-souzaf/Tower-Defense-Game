using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static bool isGameOver;

    public static bool isWaveOn;

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
        isWaveOn = true;
        OnGameStart.Invoke();
        Debug.Log("Game has started");
    }

    // TODO: Add a functionality to speed up the game

    // TODO: Let the player choose between auto start every new round or wait for player to press start;

    // TODO: Camera movement - change rotation when it goes down
}
