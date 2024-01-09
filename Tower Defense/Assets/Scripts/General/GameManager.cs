using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool isGameOver;

    public int levelToUnlock;

    private void Start()
    {
        isGameOver = false;
    }
    public void EndGame()
    {
        isGameOver = true;
        GetComponent<UIManager>().OnGameOver();
        Debug.Log("Game Over");
    }

    public void WinLevel()
    {
        Debug.Log("Level Finished");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}
