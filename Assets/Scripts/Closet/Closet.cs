using UnityEngine;

public class Closet : MonoBehaviour, IObject
{
    // UI canvas refs
    public GameObject hintCanvas;
    // public transform refs
    public Transform doorL;
    public Transform doorR;
    // animator refs
    private Animator doorLAnimator;
    private Animator doorRAnimator;

    public void Hover()
    {
        if (hintCanvas!= null) {
            hintCanvas.SetActive(true);
        }
    }
    public void Unhover()
    {
        if (hintCanvas!= null) {
            hintCanvas.SetActive(false);
        }
    }
    public void LeftClick()
    {
        doorLAnimator.SetBool("open", false);
        doorRAnimator.SetBool("open", false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorLAnimator = doorL.GetComponent<Animator>();
        doorRAnimator = doorR.GetComponent<Animator>();
    }
}
