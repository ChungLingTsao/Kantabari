using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// StickyBall.cs,
// @author Charles Tsao
//
// This main script handles most of the functionality of the sticky ball.
// This script contains object restrictions, the 'sticky' functionality and ball attributes.
public class StickyBall : MonoBehaviour
{
    // Facing Angle Information
    public float facingAngle = 0;
    float x = 0;
    float z = 0;
    Vector2 unitV2;

    // For mobile controls
    public Joystick joystick;

    // Camera Related
    public GameObject cameraReference;
	public GameObject ballManager;
    float distanceToCamera = 5;

    // Final winning condition of 350kg
    float winningMass = 350;

    // Ball Attributes
    public float size;
	float currentSpeed = 1;

    // The categories for the objects
    public GameObject category1;
    bool category1Unlocked = false;
    public GameObject category2;
    bool category2Unlocked = false;
    public GameObject category3;
    bool category3Unlocked = false;
    public GameObject category4;
    bool category4Unlocked = false;
    public GameObject category5;
    bool category5Unlocked = false;

    // Reference to UI Text Display
    public GameObject sizeUI;
    public GameObject levelUI;

    // Pickup Sound Reference
    public AudioClip pickupSound;

    // Update is called once per frame
    void Update()
    {
        // User Controls for PC
        //x = Input.GetAxis("Horizontal") * Time.deltaTime * -20;
        //z = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed * 200;

        // User Controls for Android
        x = joystick.Horizontal * Time.deltaTime * -100;
        z = joystick.Vertical * Time.deltaTime * 500;

        // Facing Angle
        facingAngle += x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));

        // Display speed 
        FindObjectOfType<BallUIManager>().SetSpeed(currentSpeed);
    }

    // Update is called at a fixed rate
    private void FixedUpdate()
    {
        // Apply Force Behind the Ball
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x, 0, unitV2.y) * z * 3);

        // Set Camera Position Behind the Ball Based on Rotation
        cameraReference.transform.position = new Vector3(-unitV2.x * distanceToCamera, distanceToCamera, -unitV2.y * distanceToCamera) + this.transform.position;
        
        // Checking if new Pickup Categories are Unlocked
        UnlockPickupCategories();

        // Checking Win Condition
        WinCondition();
    }

    // Conditionals for unlocking object categories
    void UnlockPickupCategories()
    {
        // 1kg
        if (category1Unlocked == false) {
            if (size >= 1) { // at 1kg
                category1Unlocked = true;
                for (int i = 0; i < category1.transform.childCount; i++) {
                    category1.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        } else if (category2Unlocked == false) {
            if (size >= 1.5) { // at 1.5kg
                category2Unlocked = true;
                for (int i = 0; i < category2.transform.childCount; i++) {
                    category2.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        } else if (category3Unlocked == false) {
            if (size >= 3) { // at 3kg
                category3Unlocked = true;
                for (int i = 0; i < category3.transform.childCount; i++) {
                    category3.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        } else if (category4Unlocked == false) {
            if (size >= 150) { // at 150kg
                category4Unlocked = true;
                for (int i = 0; i < category3.transform.childCount; i++) {
                    category4.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        } else if (category5Unlocked == false) {
            if (size >= 250) { // at 250kg
                category5Unlocked = true;
                for (int i = 0; i < category3.transform.childCount; i++) {
                    category5.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        }
    }

    //Functionality to pick up objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Sticky")) {
            
            // Grow the Sticky Ball
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            size += other.GetComponent<MassValue>().mass;
            distanceToCamera += 0.08f;
            other.enabled = false;

            // Becomes Child so it stays with the Sticky Ball
            other.transform.SetParent(this.transform);

            // other.GetComponent<Collider>().isTrigger = false; // Testing Collider attributes
            // other.GetComponent<Collider>().enabled = true;

            // Set the UI Text for Ball Size
            FindObjectOfType<BallUIManager>().SetMass(size);

            // Sound effect when we Pick up a Sticky Object
            this.GetComponent<AudioSource>().PlayOneShot(pickupSound);
        }
    }

    // Adds speed via pickup
    public void AddSpeed(float speed)
    {
        currentSpeed += speed;
    }

    // Slows speed via pickup
    public void SlowSpeed()
    {
        currentSpeed = currentSpeed * 0.65f;
    }

    // The game is won when the winning mass has been reached
    void WinCondition()
    {
        if (size > winningMass)
        {
            levelUI.GetComponent<Text>().text = "LEVEL COMPLETE! GHOST KING CHARLES IS PROUD OF YOU!";
            Invoke("DelayedAction", 8f);
        }
    }

    // Delay for better scene transition
    void DelayedAction()
    {
        SceneManager.LoadScene("Menu");
    }
}
