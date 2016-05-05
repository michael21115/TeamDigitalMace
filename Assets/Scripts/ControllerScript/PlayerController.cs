using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour {

    [SerializeField] float waitTime = 10f;
    [SerializeField] float currTime = 0f;
        
    public int playerNo;
    public Color playerColor;
    public float speed = 2000f;
    public float dashSpeed = 5f;
    public float dashBoost = 1000f;
    bool canDash = true;
    bool hasDashed = false;

    void Start ()
    {
        if (playerNo == 0)
        {
            playerColor = Color.red;
        }
        else if (playerNo == 1)
        {
            playerColor = Color.blue;
        }
        else if (playerNo == 2)
        {
            playerColor = Color.yellow;
        }
        else if (playerNo == 3)
        {
            playerColor = Color.green;
        }
    }

	// Use this for initialization
	void Update ()
    {
        if (hasDashed)
        {
            currTime += Time.deltaTime;
            if (currTime >= waitTime)
            {
                hasDashed = false;
                canDash = true;
                currTime = 0f;
            }
        }

        PlayerInput();
    }
    /// <summary>
    /// Checks for and runs player input
    /// </summary>
    void PlayerInput()
    {
        // For each joystick attached, control that coresponding player
        // Maybe we will have a player select screen?
        float horizontal = Input.GetAxis("Joy " + playerNo + " Horizontal");
        float vertical = Input.GetAxis("Joy " + playerNo + " Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed;

        //players[i].position += movement * Time.deltaTime;

        Ray groundCheck = new Ray(transform.position, -transform.up);
        RaycastHit groundCheckInfo = new RaycastHit();

        if (Physics.Raycast(groundCheck, out groundCheckInfo, (transform.localScale.y * 0.5f * 1.05f)))
        {
            GetComponent<Rigidbody>().velocity = (movement + Physics.gravity) * Time.deltaTime;
        }
        else
        {
            GetComponent<Rigidbody>().velocity += Physics.gravity * Time.deltaTime;
        }

        if (movement != Vector3.zero)
        {
            //snaps to movement direction... a little jumpy
           transform.forward = Vector3.Normalize(movement);
        }

        //Add player buttons and data loss capture

        // Input for xBox Controllers
        if (playerNo < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[playerNo].Contains("Xbox"))
            {
                // Xbox Controller A button
                if (Input.GetButtonDown("Joy " + playerNo + " A"))
                {
                    Debug.Log("Player " + playerNo + " pressed 'A'");
                    Cross_Button();
                }
                // Xbox Controller B button
                if (Input.GetButtonDown("Joy " + playerNo + " B"))
                {
                    Debug.Log("Player " + playerNo + " pressed 'B'");
                    Circle_Button();
                }
                // Xbox Controller X button
                if (Input.GetButtonDown("Joy " + playerNo + " X"))
                {
                    Debug.Log("Player " + playerNo + " pressed 'X'");
                    Square_Button(); 
                }
                // Xbox Controller Y button 
                if (Input.GetButtonDown("Joy " + playerNo + " Y"))
                {
                    Debug.Log("Player " + playerNo + " pressed 'Y'");
                    Triangle_Button();
                }
            }
            // Input for other (PS4) Controllers
            else if (Input.GetJoystickNames()[playerNo].Contains("Wireless"))
            {
                // PS4 Controller Square button
                if (Input.GetButtonDown("Joy " + playerNo + " A"))
                {
                    Debug.Log("Player " + playerNo + " pressed 'Square'");
                    Square_Button();
                }
                // PS4 Controller Cross button
                if (Input.GetButtonDown("Joy " + playerNo + " B"))
                {
                    Debug.Log("Player " + playerNo + " pressed 'Cross'");
                    Cross_Button();
                }
                // Xbox Controller Circle button
                if (Input.GetButtonDown("Joy " + playerNo + " X"))
                {
                    Debug.Log("Player " + playerNo + " pressed 'Circle'");
                    Circle_Button();
                }
                // Xbox Controller Triangle button 
                if (Input.GetButtonDown("Joy " + playerNo + " Y"))
                {
                    Debug.Log("Player " + playerNo + " pressed 'Triangle'");
                    Triangle_Button();
                }
            }
        }
    }

    void Cross_Button ()
    {
        if (GetComponent<ObjectInteraction>().throwItem)
        {
            Transform throwObject = GetComponent<ObjectInteraction>().hands[0].GetChild(0);
            Rigidbody objectRB = throwObject.GetComponent<Rigidbody>();

            // throw the game object in your off hand
            GetComponent<ObjectInteraction>().throwItem = false;
            throwObject.tag = "Projectile";
            objectRB.constraints = RigidbodyConstraints.None;
            objectRB.constraints = RigidbodyConstraints.FreezeRotation;
            //objectRB.detectCollisions = true; // re-enables collision detection
            objectRB.mass = GetComponent<ObjectInteraction>().objectMass; // resets the mass of the object before it is thrown
            objectRB.AddForce(transform.forward * GetComponent<ObjectInteraction>().throwForce * 1000f);
            objectRB.useGravity = true;
            GetComponent<ObjectInteraction>().hands[0].DetachChildren();
        }
    }
    void Circle_Button ()
    {

    }
    void Triangle_Button ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Square_Button ()
    {
        if (canDash && !hasDashed)
        {
            canDash = false;
            hasDashed = true;
            GetComponent<Rigidbody>().AddForce((Vector3.up * dashBoost) + (transform.forward * dashSpeed * dashBoost));
        }

        if (GetComponent<ObjectInteraction>().throwItem)
        {
            Transform throwObject = GetComponent<ObjectInteraction>().hands[0].GetChild(0);
            Rigidbody objectRB = throwObject.GetComponent<Rigidbody>();

            // drop the game object in your off hand
            GetComponent<ObjectInteraction>().throwItem = false;
            objectRB.constraints = RigidbodyConstraints.None;
            objectRB.constraints = RigidbodyConstraints.FreezeRotation;
            objectRB.mass = GetComponent<ObjectInteraction>().objectMass; // resets the mass of the object before it is thrown
            objectRB.AddForce(transform.up * 500);
            objectRB.useGravity = true;
            GetComponent<ObjectInteraction>().hands[0].DetachChildren();
        }
    }
}
