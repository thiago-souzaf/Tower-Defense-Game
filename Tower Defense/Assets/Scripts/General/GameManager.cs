using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static bool isGameOver;

    public int levelToUnlock;

    public UnityEvent OnGameOver;

    public UnityEvent OnLevelComplete;

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
}
