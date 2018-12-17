// GameManager.cs
// by Dickson Cho
// August 2016
using UnityEngine;
using System.Collections;

/// <summary>
/// The current state of the game, once Level One has loaded
/// </summary>
public enum GameState
{
	eWatchingBillboard,
	eFlyingIntroCamera,
	eInGame,

	MAX_STATES
}

/// <summary>
/// Determines game-wide events, such as win conditions
/// </summary>
public class GameManager
{
	public float m_MetersPerSecond;				// Current speed, in meters per second
	public int m_Kilograms;						// Current mass, in kilograms
	public GameState m_State = GameState.eWatchingBillboard;	// We start out watching the billboard

	public int m_WinConditionMass = 40;			// DICKSON TODO: Put in an INI (collect 80% of all stuff out there)

	private static GameManager m_Instance;

	public static GameManager GetInstance()
	{
		if (m_Instance == null)
		{
			m_Instance = new GameManager();
		}
		return m_Instance;
	}

	public void CollectMass(int mass)
	{
		m_Kilograms += mass;
		
		if (CheckWinCondition())
		{
			WinGame();
		}
	}

	public void AdvanceGameState()
	{
		switch(m_State)
		{
			case GameState.eWatchingBillboard:
				m_State = GameState.eFlyingIntroCamera;
				GameObject.Find("Audio").transform.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
				break;
			case GameState.eFlyingIntroCamera:
				m_State = GameState.eInGame;
				GameObject.Find("Managers").GetComponent<UIManager>().DisplayHUD(true);
				break;
			case GameState.eInGame:
				break;
			default:
				break;
		}
	}

	/// <summary>
	/// Constructor remains private for singletons
	/// </summary>
	private GameManager()
	{
	}

	/// <summary>
	/// Did the player win the game?
	/// </summary>
	/// <returns>Returns TRUE if we win, FALSE otherwise</returns>
	private bool CheckWinCondition()
	{
		return m_Kilograms >= m_WinConditionMass;
	}

	/// <summary>
	/// We won the game!
	/// </summary>
	private void WinGame()
	{
		GameObject.Find("Managers").GetComponent<UIManager>().DisplayWinScreen();
		GameObject.Find("Audio").transform.Find("Winner").GetComponent<AudioSource>().Play();
	}
}
