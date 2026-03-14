using UnityEngine;

public class Carpet : MonoBehaviour, IObject
{
    // animator refs
    private Animator carpetAnimator;

    public void LeftClick()
    {
        carpetAnimator.SetBool("move", !carpetAnimator.GetBool("move"));
    }
    public void RightClick()
    {
        Debug.Log("optional interaction");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carpetAnimator = transform.GetComponent<Animator>();
    }
}

