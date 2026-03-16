using UnityEngine;

public class DoorKnob : MonoBehaviour, IObject {

    // UI canvas refs
    // animator refs
    private Animator doorKnobAnimator;
    // bools

    public void Hover()
    {
    }
    public void Unhover()
    {
    }
    public void LeftClick()
    {
        // if animator is present
        if (doorKnobAnimator != null)
        {
            Debug.Log("animator present");
            //doorKnobAnimator.SetTrigger("turn");
        }
    }

    void Start()
    {
        doorKnobAnimator = transform.GetComponent<Animator>();
    }

    void Update()
    {
    }
}
