using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // public variables
    public float sensitivity = 1.0f;
    public float speed = 1.0f;
    public float runSpeed = 2.0f;
    public Transform cameraTransform;

    // private variables
    private Mouse mouse;
    private float pitch = 0f;
    private Keyboard keyboard;
    private Vector3 velocity;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        // hide cursor and lock mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // get the rgidbody of the player object
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // get camera rotation inputs from mousepos
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

        // get keyboard inputs
        keyboard = Keyboard.current;

        if (keyboard != null)
        {
            float x = 0f;
            float z = 0f;
            float run = 1.0f;

            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) z += 1f;

            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) z -= 1f;

            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) x += 1f;

            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) x -= 1f;

            if (keyboard.leftShiftKey.isPressed) run = runSpeed;

            // get the camra forward and right
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            // calculate the movement based on normalized cam direction and the velocity applied with keyboard inputs
            velocity = (camRight.normalized * x + camForward.normalized * z) * speed * run;
            Debug.Log("velocity: " + velocity);
        }

        // get interaction inputs from mouse clicks
        if (mouse != null && mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log("left mouse button clicked...");
        }
        if (mouse != null && mouse.rightButton.wasPressedThisFrame)
        {
            Debug.Log("right mouse button clicked...");
        }
    }

    // move the rigidbody
    void FixedUpdate()
    {
        rb.linearVelocity = velocity;
    }
}    
