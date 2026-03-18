using UnityEngine;

public class FinalMenu : MonoBehaviour
{
    // public refs
    public Rigidbody playerRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    void OnTriggerEnter()
    {
        GameWinUI.Instance.GameWin();
        FreezePlayer();
    }

    private void FreezePlayer()
    {
        playerRB.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }
}
