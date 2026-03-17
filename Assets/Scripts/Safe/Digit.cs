using UnityEngine;

public class Digit : MonoBehaviour, IObject
{
    public Animator digitAnimator;
    private int currDigit = 0;
    public void Hover() {}
    public void Unhover() {}
    public void LeftClick()
    {
        // turn the digit with each click
        // increase current digit number with each click
        if (currDigit == 9)
        {
            currDigit = 0;
        } else
        {
            currDigit++;
        }
        Debug.Log("curr digit: " + currDigit);
        if (digitAnimator!= null)
        {
            digitAnimator.SetInteger("digit", currDigit);
        }
        
    }
    void start()
    {
        currDigit = 0;
    }

}
