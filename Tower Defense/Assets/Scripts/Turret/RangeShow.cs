using UnityEngine;

public class RangeShow : MonoBehaviour
{
	[SerializeField] GameObject rangeIndicator;
    private void Start()
    {
        rangeIndicator.SetActive(false);
    }
    public void ShowRangeIndicator(bool show)
	{
        rangeIndicator.SetActive(show);
	}
	
}
