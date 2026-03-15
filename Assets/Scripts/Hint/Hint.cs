using UnityEngine;

public class Hint : MonoBehaviour
{
    // make it so that the hint always face forward
    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }

    void Start()
    {
        // default to hide hint
        gameObject.SetActive(false);
    }
}
