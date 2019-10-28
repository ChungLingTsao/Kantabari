using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// LevelSwitch.cs,
// @author Charles Tsao
//
// This script provides functionality for the LevelSwitch pickup
public class LevelSwitch : MonoBehaviour
{
    public float delayTime = 6f;
    public GameObject LevelText;

    // Displays level complete message
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            LevelText.GetComponent<Text>().text = "Level Complete! Starting next level!";
            Invoke("DelayedAction", delayTime); 
        }
    }

    // Loads next level after a transition delay
    void DelayedAction()
    {
        SceneManager.LoadScene("Katamari2");
    }
}
