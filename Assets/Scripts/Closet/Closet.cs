using UnityEngine;

public class Closet : MonoBehaviour, IObject
{
    // public transform refs
    public Transform doorL;
    public Transform doorR;
    // animator refs
    private Animator doorLAnimator;
    private Animator doorRAnimator;

    public void LeftClick()
    {
        doorLAnimator.SetBool("open", false);
        doorRAnimator.SetBool("open", false);
    }
    public void RightClick()
    {
        Debug.Log("optional interaction");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorLAnimator = doorL.GetComponent<Animator>();
        doorRAnimator = doorR.GetComponent<Animator>();
    }
}
