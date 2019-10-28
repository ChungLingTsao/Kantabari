using UnityEngine;

// SlowPickup.cs,
// @author Charles Tsao
//
// This script provides functionality for the Slow pickup.
// Decreases the speed of ball on collision and displays particle effects.
public class SlowPickup : MonoBehaviour
{
    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            FindObjectOfType<StickyBall>().SlowSpeed();
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
