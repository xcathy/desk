using UnityEngine;

public class ClosetDoorR : MonoBehaviour, IObject
{
    // animator refs
    private Animator doorRAnimator;

    public void LeftClick()
    {
        doorRAnimator.SetBool("open", !doorRAnimator.GetBool("open"));
    }
    public void RightClick()
    {
        Debug.Log("optional interaction");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorRAnimator = transform.GetComponent<Animator>();
    }
}
