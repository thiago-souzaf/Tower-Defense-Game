using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private UIManager uiManager;
    private GameManager gameManager;
    
    // Money properties
    public int startMoney = 400;
    private int money;
    public int Money
    {
        get { return money; }
        set { money = value; uiManager.UpdateMoney(money); }
    }

    // Lives properties
    public int startLives = 10;
    private int lives;
    public int Lives
    {
        get { return lives; }
        set
        { 
            lives = value;
            uiManager.UpdateLives(lives);
            if (lives <= 0)
            {
                gameManager.EndGame();
            }
        }
    }

    void Start()
    {
        uiManager = GetComponent<UIManager>();
        gameManager = GetComponent<GameManager>();

        Money = startMoney;
        Lives = startLives;
    }
}
