using UnityEngine;

public class Closet : MonoBehaviour, IObject
{
    // UI canvas refs
    public GameObject hintCanvas;
    // animator refs
    public Animator doorLAnimator;
    public Animator doorRAnimator;
    public Animator safeDoorAnimator;

    public void Hover(){}
    public void Unhover(){}
    public void LeftClick()
    {
        doorLAnimator.SetBool("open", false);
        doorRAnimator.SetBool("open", false);
        safeDoorAnimator.SetBool("unlock", false);
    }
}
