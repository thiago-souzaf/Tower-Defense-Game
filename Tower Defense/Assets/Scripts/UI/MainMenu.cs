using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string mainLevel = "MainLevel";
	public void Play()
	{
		SceneManager.LoadScene(mainLevel);
	}

	public void Quit()
	{
		Debug.Log("Quiting does not work on unity editor, only when the game is built");
		Application.Quit();
	}
}
