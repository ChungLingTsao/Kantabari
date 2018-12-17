using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

// TimerController.cs,
// @author Charles Tsao
//
// This script handles the game time and deals with gameover scenarios
public class TimerController : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject timeText;

    private bool gameOver;
    public float targetTime = 180.0f; // Game time of 180 seconds 

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameOverText.GetComponent<Text>().text = "";

        // Loads Menu if GameOver
        if (gameOver == true)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Displays remaining game time
        targetTime -= Time.deltaTime;
        timeText.GetComponent<Text>().text = "Time: " + Math.Round(targetTime, 2).ToString();

        // Game over when game time reaches zero
        if (targetTime <= 0.0f)
        { 
            GameOver();
            timeText.GetComponent<Text>().enabled = false;
        }
    }

    // Displays gameover message
    public void GameOver()
    {
        gameOverText.GetComponent<Text>().text = "Game Over! Charles is Dissapointed =(";
        gameOver = true;
        Invoke("DelayedAction", 6f);  
    }

    // Provides delay for smoother transition
    void DelayedAction()
    {
        SceneManager.LoadScene("Menu");
    }
}
