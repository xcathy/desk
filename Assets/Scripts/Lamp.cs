using UnityEngine;

public class Lamp : MonoBehaviour, IObject
{
    // public vars
    public Light lighting;
    public float intensity;
    // bools
    private bool on = false;

    public void LeftClick()
    {
        on = !on;
    }
    public void RightClick()
    {
        Debug.Log("optional interaction");
    }

    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        lighting.intensity = on ? intensity : 0.0f;
    }
}
