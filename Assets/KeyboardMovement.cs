using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float forceMultiplier;
    private bool isColliding;
    private Rigidbody myRigidbody;
    private Collider myCollider;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody>();
        myCollider = transform.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            if (horizontalInput > 0)
            {
                transform.Rotate(new Vector3(0, 0, -20 * Time.deltaTime), Space.Self);
            } 
            else 
            {
                transform.Rotate(new Vector3(0, 0, 20 * Time.deltaTime), Space.Self);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            var force = forceMultiplier * Time.deltaTime * 10;
            myRigidbody.AddRelativeForce(new Vector3(0, force, 0));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }

    void OnCollisionExit(Collision collision) 
    {
        isColliding = false;
    }
}
