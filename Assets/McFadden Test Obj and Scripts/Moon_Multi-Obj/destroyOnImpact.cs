using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnImpact : MonoBehaviour
{
    
    ///////READ ME: Put this on the explosion obj.

    public float blastRadius = 6;
    private float moonY;
    private GameObject moonObj;
    
    // Start is called before the first frame update
    void Start()
    {
        moonObj = GameObject.Find("MoonObj");
        
        moonY = (int) moonObj.transform.localScale.y;
        transform.localScale = new Vector3(blastRadius*2, moonY, blastRadius*2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        //Destroy(gameObject);
        if (collision.gameObject.tag == "Moon")
        {           
            Destroy(collision.gameObject);
            StartCoroutine(moonObj.transform.GetComponent<MoonHealthScript>().CountCurrentChildren());
        }
        
    }
}
