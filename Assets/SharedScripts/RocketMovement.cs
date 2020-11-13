using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float forceMultiplier = 2;

    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // left mouse click
        if (Input.GetMouseButton(0))
        {
            myRigidbody.AddForce(new Vector3(0, 10, 0) * forceMultiplier, ForceMode.Acceleration);
        }
    }
}
