using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionForceScript : MonoBehaviour
{
    public float force = 10f;
    public Collision col;
    public float forceOffset = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {
        //col = collision;

        testDeformScript deformer = collision.collider.GetComponent<testDeformScript>();
        Debug.Log("collision with: " + collision.gameObject.name);
        if (deformer) 
            {				
                ContactPoint contact = collision.contacts[0];
                Vector3 pos = contact.point;
				deformer.AddDeformingForce(pos, force);
                Debug.Log("the contact point x, y, z is " + contact.point.x + "," +  contact.point.y + "," + contact.point.z);
			}
            

       // HandleInput();
    }

    /*void HandleInput()
    {    
        testDeformScript deformer = col.collider.GetComponent<testDeformScript>();
        if (deformer) 
            {				
                ContactPoint contact = col.contacts[0];
                Vector3 pos = contact.point;
				deformer.AddDeformingForce(pos, force);
			}
    }*/
}
