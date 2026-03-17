using UnityEngine;
using System.Linq;

public class SafeHandle : MonoBehaviour, IObject
{
    public static SafeHandle Instance { get; private set; }
    // public refs
    public int[] passCode = new int[4];
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
            //Debug.Log("passcode correct");
            animator.SetBool("unlock", true);
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
}
