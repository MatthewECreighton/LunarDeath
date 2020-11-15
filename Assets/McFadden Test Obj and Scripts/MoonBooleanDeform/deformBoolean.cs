using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deformBoolean : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("boolean collision with: " + collision.gameObject.name);			
        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point;
        Debug.Log("the boolean contact point x, y, z is " + contact.point.x + "," +  contact.point.y + "," + contact.point.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
