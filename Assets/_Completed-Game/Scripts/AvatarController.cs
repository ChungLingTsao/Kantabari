using UnityEngine;

// AvatarController.cs,
// @author Charles Tsao
//
// This script handles the character animation for pushing the ball. 
// This method involves the character being tied to the camera at a set distance.
public class AvatarController : MonoBehaviour {

    public Camera playerCamera;
    public GameObject itemObject;
    public GameObject ballObject;
	public Animator anim;

    public float distance = 3.0f;

    // Use this for initialization
    void Start () {
		playerCamera = Camera.main;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    void Update()
    {
        // Sets character at a set distance from camera and also same y-position as ball.
        // This is a temporary fix as going down ramps will force the character to clip through the ramp
		if ( itemObject != null ) {
            itemObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward * distance;
			itemObject.transform.position = new Vector3(transform.position.x, ballObject.transform.position.y, transform.position.z);
            itemObject.transform.rotation = new Quaternion( 0.0f, playerCamera.transform.rotation.y, 0.0f, playerCamera.transform.rotation.w );
        }
		
        // Start animating walk after a slight keydown press
		if (Input.GetAxis("Vertical") > 0.2f) {
            anim.SetBool("isWalk", true);
		} else {
			anim.SetBool("isWalk", false);
        }

        // Start animating walk backwards after a slight keydown press
        if (Input.GetAxis("Vertical") < -0.2f)
        {
            anim.SetBool("isWalkBackwards", true);
        } else {
            anim.SetBool("isWalkBackwards", false);
        }
    }
}
