using UnityEngine;

public class ClosetDoorR : MonoBehaviour, IObject
{
    // animator refs
    public Animator safeDoorAnimator;
    private Animator animator;
    private bool open;

    public void Hover(){}
    public void Unhover(){}
    public void LeftClick()
    {
        open = !open;
        animator.SetBool("open", open);
        // close the safe door along with the left closet door
        if (open == false) safeDoorAnimator.SetBool("unlock", false);
    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
}
