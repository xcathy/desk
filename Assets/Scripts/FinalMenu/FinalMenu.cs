using UnityEngine;

public class GameWin : MonoBehaviour
{
    // public refs
    public Rigidbody playerRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    void OnTriggerEnter()
    {
        GameWinUI.Instance.GameWin();
        MenuUI.Instance.SetEnable(false);
        InventoryUI.Instance.SetEnable(false);
        PreviewUI.Instance.SetEnable(false);
        FreezePlayer();
    }

    private void FreezePlayer()
    {
        playerRB.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }
}
