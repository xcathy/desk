using UnityEngine;

public class DoorKnob : MonoBehaviour, IObject {

    // UI canvas refs
    // animator refs
    private Animator doorKnobAnimator;
    // bools
    private bool key = false;

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
            // if key is not selected, attempt to turn the doorknob, fail
            doorKnobAnimator.SetTrigger("turn");

            // if key is selected, unlock
            if (key)
            {
                doorKnobAnimator.SetTrigger("unlock");
            }
        }
    }

    void Start()
    {
        doorKnobAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
    }
}
