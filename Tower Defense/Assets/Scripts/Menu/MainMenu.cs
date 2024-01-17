using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public float CameraYRotation = 115f;
	public CameraRotation camRotation;
	
	public void Quit()
	{
		Debug.Log("Quiting does not work on unity editor, only when the game is built");
		Application.Quit();
	}
}
