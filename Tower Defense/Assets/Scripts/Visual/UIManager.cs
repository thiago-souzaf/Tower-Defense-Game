using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveTxt;

    public void UpdateWave(int currentWave)
    {
        waveTxt.text = "Wave: " + currentWave;
    }
}
