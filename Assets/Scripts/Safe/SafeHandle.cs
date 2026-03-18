using UnityEngine;
using System.Collections;
using System.Linq;

public class SafeHandle : MonoBehaviour, IObject
{
    public static SafeHandle Instance { get; private set; }
    // public refs
    public int[] passCode = new int[4];
    public Animator safeDoorAnimator;
    // private refs
    private int[] answerCode = {6,7,8,3};
    private Animator animator;

    public void Hover(){}
    public void Unhover(){}
    public void LeftClick()
    {
        
        if (passCode.SequenceEqual(answerCode))
        {
            // if the passcode is 6783, open the safe
            DialogueUI.Instance.ShowDialogue("It opened!");
            
            // play the door open animation after the handle turn
            StartCoroutine(WaitForAnimation(animator, "unlock"));
            safeDoorAnimator.SetBool("unlock", true);
        } else
        {
            // otherwise, display dialogue instead
            DialogueUI.Instance.ShowDialogue("The handle won't turn, seems like " +
                passCode[0] + passCode[1] + passCode[2] + passCode[3]
                + " is not the correct passcode.");
        }
    }
    
    public void SetDigit(int index, int codeNum)
    {
        passCode[index] = codeNum;
    }

    void Start()
    {
        Instance = this;
        animator = gameObject.GetComponent<Animator>();
    }

    IEnumerator WaitForAnimation(Animator anim, string animBool)
    {
        anim.SetBool(animBool, true);

        // Wait until the animation finishes
        yield return new WaitForSeconds(2.0f);
    }
}
