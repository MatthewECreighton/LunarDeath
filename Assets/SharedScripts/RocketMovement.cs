using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public Transform objectToFollow;
    public float forceMultiplier = 2;

    private Rigidbody myRigidbody;
    private Collider myCollider;
    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody>();
        myCollider = transform.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == false)
        {
            // rotation
            var vectorBetweenObjects = objectToFollow.position - transform.position;
            var normalizedDirection = vectorBetweenObjects.normalized;
            var rotatedDirection = Quaternion.Euler(0, 0, 270) * normalizedDirection;

            var lookRotation = Quaternion.LookRotation(rotatedDirection);
            transform.rotation = lookRotation;
            
            Debug.Log(vectorBetweenObjects);

            // transform.LookAt(objectToFollow.transform, Vector3.up);
        }

        // left mouse click
        if (Input.GetMouseButton(0))
        {
            var vectorBetweenObjects = (objectToFollow.position - transform.position).normalized;
            // for some reason, unity doesn't apply the force the right way when the cursor is below the rocket
            if (vectorBetweenObjects.y > 0) 
            {
                myRigidbody.AddRelativeForce(transform.up * forceMultiplier * Time.deltaTime, ForceMode.Force);
            }
            else 
            {
                myRigidbody.AddRelativeForce(transform.up * forceMultiplier * Time.deltaTime * -1, ForceMode.Force);
            }
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
