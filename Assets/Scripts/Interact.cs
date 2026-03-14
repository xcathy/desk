using UnityEngine;

interface IObject
{
    public void LeftClick();
    public void RightClick();
}

public class Interact : MonoBehaviour
{
    // public vars
    public Transform Cam;
    public float range = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Update()
    {
        // attempt to left click object
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = new Ray(Cam.position, Cam.forward);

            if (Physics.Raycast(r, out RaycastHit hitInfo, range))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IObject obj))
                {
                    obj.LeftClick();
                }
            }
        }

        // attempt to right click object
        if (Input.GetMouseButtonDown(1))
        {
            Ray r = new Ray(Cam.position, Cam.forward);

            if (Physics.Raycast(r, out RaycastHit hitInfo, range))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IObject obj))
                {
                    obj.RightClick();
                }
            }
        }
    }
}
