using UnityEngine;
using UnityEngine.InputSystem;

interface IObject
{
    public void Grab();
}

public class Interact : MonoBehaviour
{
    // public vars
    public Transform Cam;
    public float range = 10.0f;

    // input refs
    private Mouse mouse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get mouse
        mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        // attempt to grab object when left mouse button is pressed
        if (mouse.leftButton.isPressed)
        {
            Ray r = new Ray(Cam.position, Cam.forward);

            if (Physics.Raycast(r, out RaycastHit hitInfo, range))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IObject obj))
                {
                    obj.Grab();
                }
            }
        }
    }
}
