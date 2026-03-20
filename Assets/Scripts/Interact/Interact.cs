using UnityEngine;

interface IObject
{
    public void Hover();
    public void Unhover();
    public void LeftClick();
}

public class Interact : MonoBehaviour
{
    // public vars
    public Transform Cam;
    public float range = 10.0f;
    // private vars
    private IObject last = null;

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
            //Debug.Log("raycast hit: " + hit.collider.name);
            // disable raycast hits on ignore raycast layer
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
            {
                return;
            }

            var obj = hit.collider.GetComponentInParent<IObject>();
            if (obj != null)
            {
                // if the object is different from the last object, change the hover status
                // if the object is still the same with the last object, keep the hover status
                if (obj != last)
                {
                    // unhovers the last object and hovers to the new object if they are present
                    last?.Unhover();
                    obj?.Hover();
                    // assign the obj as the new last obj
                    last = obj;
                }
                // attempt to left click object
                if (Input.GetMouseButtonDown(0)) obj.LeftClick();   
            } else
            {
                // if no interactable object is hit by raycast, remove the last obj refs
                last?.Unhover();
                last = null;
            }
        } 
    }
}
