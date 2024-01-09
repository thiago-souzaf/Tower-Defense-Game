using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public string mainLevel = "MainLevel";

	public SceneFader sceneFader;
	public void Play()
	{
		sceneFader.FadeTo(mainLevel);
	}

	public void Quit()
	{
		Debug.Log("Quiting does not work on unity editor, only when the game is built");
		Application.Quit();
	}
}
