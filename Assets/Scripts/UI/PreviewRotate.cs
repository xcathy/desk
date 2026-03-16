using UnityEngine;

public class PreviewRotate : MonoBehaviour
{
    public float speed = 800f;
    private bool drag = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) drag = true;
        if (Input.GetMouseButtonUp(0)) drag = false;

        if (drag)
        {
            float dx = Input.GetAxis("Mouse X");
            float dy = Input.GetAxis("Mouse Y");

            transform.Rotate(Vector3.up, -dx * speed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right, dy * speed * Time.deltaTime, Space.Self);
        }
    }
}
