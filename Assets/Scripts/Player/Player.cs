using UnityEngine;

public class Player : MonoBehaviour
{
    // public variables
    public float sensitivity = 1.0f;
    public float speed = 1.0f;
    public float runSpeed = 2.0f;
    public Transform cameraTransform;

    // private variables
    private Rigidbody rb;
    private Animator animator;
    private float pitch = 0f;
    private Vector3 velocity;

    // animation bools
    private bool walking = false;
    private bool running = false;
    private bool interact = false;

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
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // rotate player horizontally
        transform.Rotate(0f, mouseX, 0f);

        // rotate camera vertically
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // get interaction inputs from mouse clicks
        interact = Input.GetMouseButton(0);
        if (Input.GetMouseButton(1)) Debug.Log("right mouse button clicked...");

        // Keyboard Inputs
        float x = 0f;
        float z = 0f;
        float run = 1.0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) z += 1f;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) z -= 1f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x += 1f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) x -= 1f;
        // set speed to running speed if left shift is pressed
        if (Input.GetKey(KeyCode.LeftShift)) run = runSpeed;

        // get the camra forward and right
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        // calculate the movement based on normalized cam direction and the velocity applied with keyboard inputs
        velocity = (camRight.normalized * x + camForward.normalized * z) * speed * run;

        // see if the walking or running animation should play
        walking  = new Vector2(velocity.x, velocity.z).sqrMagnitude > 0.01f;
        running = run > 1.0f;

        // Set Bools for Animator
        animator.SetBool("walking", walking);
        animator.SetBool("running", running);
        animator.SetBool("interact", interact);
    }

    // move the rigidbody
    void FixedUpdate()
    {
        rb.linearVelocity = velocity;
    }
}    
