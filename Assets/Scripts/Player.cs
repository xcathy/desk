using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // public variables
    public float sensitivity = 1.0f;
    public float speed = 1.0f;
    public Transform cameraTransform;

    // private variables
    private Mouse mouse;
    private float pitch = 0f;
    private Keyboard keyboard;
    private Vector3 keyboardMovement;
    private Rigidbody rb;

    void Start()
    {
        // hide cursor and lock mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // get the rgidbody of the player object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse inputs
        mouse = Mouse.current;
        float mouseX = mouse.delta.x.ReadValue() * sensitivity;
        float mouseY = mouse.delta.y.ReadValue() * sensitivity;
        Debug.Log("mouse x: " + mouseX + " mouse y: " + mouseY);

        // rotate player horizontally
        transform.Rotate(0f, mouseX, 0f);

        // rotate camera vertically
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        if (mouse != null && mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log("left mouse button clicked...");
        }
        if (mouse != null && mouse.rightButton.wasPressedThisFrame)
        {
            Debug.Log("right mouse button clicked...");
        }

        // get keyboard inputs
        keyboard = Keyboard.current;

        if (keyboard != null)
        {
            float x = 0f;
            float z = 0f;

            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
                z += 1f;

            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
                z -= 1f;

            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
                x += 1f;

            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
                x -= 1f;

            keyboardMovement = new Vector3(x, 0f, z).normalized;
            Debug.Log("keyboard moved: " + keyboardMovement);
        }
    }

    // move the rigidbody
    void FixedUpdate()
    {
        Vector3 moveAmount = keyboardMovement * speed;
        rb.linearVelocity = new Vector3(moveAmount.x * speed, rb.linearVelocity.y, moveAmount.z * speed);
    }
}    
