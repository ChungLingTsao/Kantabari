using UnityEngine;

// SpeedPickup.cs,
// @author Charles Tsao
//
// This script provides functionality for the SpeedUp pickup.
// Increases speed of ball on collision and displays particle effects.
public class SpeedPickup : MonoBehaviour {

    public int value = 1;
    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            FindObjectOfType<StickyBall>().AddSpeed(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
