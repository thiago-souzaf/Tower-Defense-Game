using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool isGameOver;

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
}
