using UnityEngine;

public class FinalMenu : MonoBehaviour
{
    public Rigidbody playerRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
