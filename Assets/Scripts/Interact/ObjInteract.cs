using UnityEngine;

public class ObjInteract : MonoBehaviour, IObject
{
    // animator refs
    public Animator animator;
    public string boolName;
    // light refs (optional)
    public Light lighting;
    public float intensity;
    // bools
    // light bools
    private bool on = false;

    public void LeftClick()
    {
        // if animator is present
        if (animator != null)
        {
            animator.SetBool(boolName, !animator.GetBool(boolName));
        }

        // if lighting is present
        if (lighting != null)
        {
            on = !on;
        }
    }
    public void RightClick()
    {
        Debug.Log("optional interaction");
    }

    void Start()
    {
        // if animator is present
        if (animator != null)
        {
            animator = transform.GetComponent<Animator>();
        }
        // if lighting is present
        if (lighting != null)
        {
            on = false;
        }
    }

    void Update()
    {
        // if lighting is present
        if (lighting != null)
        {
            lighting.intensity = on ? intensity : 0.0f;
        }
    }
}

