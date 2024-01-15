using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
	public Color activeColor;
	public Color inactiveColor;
	public RawImage speedButtonImage;

	private bool isSpeedButtonActive;

    public void Start()
    {
		isSpeedButtonActive = Time.timeScale > 1.5f;
		speedButtonImage.color = isSpeedButtonActive ? activeColor : inactiveColor;
    }

    public void ToggleColor()
	{
		speedButtonImage.color = isSpeedButtonActive ? inactiveColor : activeColor;
		isSpeedButtonActive = !isSpeedButtonActive;
	}
}
