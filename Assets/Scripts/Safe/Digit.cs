using UnityEngine;

public class Digit : MonoBehaviour, IObject
{
    public GameObject hintCanvas;
    public Animator digitAnimator;
    private int currDigit = 0;
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
        // turn the digit with each click
        // increase current digit number with each click
        if (currDigit == 9)
        {
            currDigit = 0;
        } else
        {
            currDigit++;
        }
        if (digitAnimator!= null)
        {
            digitAnimator.SetInteger("digit", currDigit);
        }

        // update the code depending on the user inputs
        if (gameObject.name == "digitA") SafeHandle.Instance.SetDigit(0, currDigit);
        if (gameObject.name == "digitB") SafeHandle.Instance.SetDigit(1, currDigit);
        if (gameObject.name == "digitC") SafeHandle.Instance.SetDigit(2, currDigit);
        if (gameObject.name == "digitD") SafeHandle.Instance.SetDigit(3, currDigit);
    }
    void start()
    {
        currDigit = 0;
        hintCanvas.SetActive(false);
    }

}
