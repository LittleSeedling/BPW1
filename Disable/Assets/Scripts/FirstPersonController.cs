using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    public float jumpSpeed = 7.0f;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;

    float verticalVelocity = 0;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = true;
        CharacterController characterController = GetComponent<CharacterController>(); // Creating a charactercontroller called "cc"
    }

    // Update is called once per frame
    void Update()
    {

        // ROTATION
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity; // rotating left and right with the camera view (mouse)
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity; // rotating up and down with the camera view (mouse)
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // MOVEMENTTT
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;// Making a variable + getting the vertical axis for forward and backward movement
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;// Making a variable + getting the horizontal axis for sideward movement

        Vector3 speed = new Vector3(sideSpeed, Physics.gravity.y, forwardSpeed); // Making the speed a vector (no idea what it means right now)

        speed = transform.rotation * speed; // When the camera rotates, your forward is really forward in the way you're facing

        characterController.Move(speed * Time.deltaTime); // to be able to move

        if (characterController.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; // Increasing the gravity exponentially (which is how it is in nature)
        }

        if (Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }

    }
}
