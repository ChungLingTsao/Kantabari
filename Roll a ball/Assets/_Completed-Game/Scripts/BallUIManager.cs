using System;
using UnityEngine;
using UnityEngine.UI;

// BallUIManager.cs,
// @author Charles Tsao
//
// This script handles displaying the mass and speed of the ball
public class BallUIManager : MonoBehaviour {

    public float currentMass;
    public float currentSpeed;
    public GameObject sizeUI;
    public GameObject speedUI;

    //Singleton Instance
    private static BallUIManager m_Instance;

    public static BallUIManager GetInstance()
    {
        if (m_Instance == null)
        {
            m_Instance = new BallUIManager();
        }
        return m_Instance;
    }
	
    // Gets current mass of ball and displays on UI
    public void SetMass(float mass)
    {
        currentMass = mass;
        sizeUI.GetComponent<Text>().text = "Mass: " + currentMass.ToString() + "kg";
    }

    // Gets current speed of ball and displays on UI
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
        speedUI.GetComponent<Text>().text = "Speed: " + Math.Round(currentSpeed, 2).ToString() + "x";
    }
}
