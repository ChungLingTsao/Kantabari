using UnityEngine;

// CameraScript.cs,
// @author Charles Tsao
//
// This script handles the main camera functionality
public class CameraScript : MonoBehaviour {

    public GameObject ball;
    Vector3 lookAtOffset;

	// Use this for initialization. Apply slight offset
	void Start () {
        lookAtOffset = new Vector3(0, 1.5f, 0);
	}
	
	// Update is called once per frame. Camera follows ball.
	void Update () {
        transform.LookAt(ball.transform.position + lookAtOffset);
	}
}
