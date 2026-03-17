using UnityEngine;

public class SafeLock : MonoBehaviour
{
    // combination lock digits refs
    public Transform digitA;
    public Transform digitB;
    public Transform digitC;
    public Transform digitD;
    // digit euler angles
    private float eulerA;
    private float eulerB;
    private float eulerC;
    private float eulerD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eulerA = digitA.eulerAngles.x;
        eulerB = digitB.eulerAngles.x;
        eulerC = digitC.eulerAngles.x;
        eulerD = digitD.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // if any of the digits changed, update the digit
        if (digitA.eulerAngles.x != eulerA)
        {
            eulerA = digitA.eulerAngles.x;
            Debug.Log("current digitA rotation x: " + eulerA);
        }

        if (digitB.eulerAngles.x != eulerB)
        {
            eulerB = digitB.eulerAngles.x;
            Debug.Log("current digitB rotation x: " + eulerB);
        }

        if (digitC.eulerAngles.x != eulerC)
        {
            eulerC = digitC.eulerAngles.x;
            Debug.Log("current digitC rotation x: " + eulerC);
        }

        if (digitD.eulerAngles.x != eulerD)
        {
            eulerD = digitD.eulerAngles.x;
            Debug.Log("current digitD rotation x: " + eulerD);
        }
    }
}
