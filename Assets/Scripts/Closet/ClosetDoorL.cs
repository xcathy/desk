using UnityEngine;

public class ClosetDoorL : MonoBehaviour, IObject
{
    // animator refs
    private Animator doorLAnimator;

    public void LeftClick()
    {
        doorLAnimator.SetBool("open", !doorLAnimator.GetBool("open"));
    }
    public void RightClick()
    {
        Debug.Log("optional interaction");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorLAnimator = transform.GetComponent<Animator>();
    }
}
