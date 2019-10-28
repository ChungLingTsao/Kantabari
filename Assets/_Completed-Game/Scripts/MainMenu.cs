using UnityEngine;
using UnityEngine.SceneManagement;

// MainMenu.cs,
// @author Charles Tsao
//
// This script is to give button functionality for the menu
public class MainMenu : MonoBehaviour {

	public string newGameScene;
	
	public void NewGame()
	{
		SceneManager.LoadScene(newGameScene);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
