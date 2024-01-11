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

    // Round properties
    private int currentRound;
    public int CurrentRound
    { 
        get { return currentRound; }
        set
        {
            currentRound = value;
            uiManager.UpdateRound(currentRound, lastRound);
        }
    }

    public int lastRound;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
        gameManager = GetComponent<GameManager>();
    }
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        CurrentRound = 0;
    }

    public void IncrementMoney(int amountToIncrement)
    {
        Money += amountToIncrement;
    }
}
