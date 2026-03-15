using UnityEngine;

interface IObject
{
    public void Hover();
    public void LeftClick();
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
        
        // looking around the world
        Ray r = new Ray(Cam.position, Cam.forward);

        if (Physics.Raycast(r, out RaycastHit hit, range))
        {
            Debug.Log("raycast hit: " + hit.collider.name);
            var obj = hit.collider.GetComponentInParent<IObject>();
            if (obj != null)
            {
                // hover on object
                obj.Hover();
                // attempt to left click object
                if (Input.GetMouseButtonDown(0)) obj.LeftClick();
                
            }

        }
    }
}
