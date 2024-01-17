using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public void Quit()
	{
		Debug.Log("Quiting does not work on unity editor, only when the game is built");
		Application.Quit();
	}
}
