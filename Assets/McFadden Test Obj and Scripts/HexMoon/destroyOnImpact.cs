using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnImpact : MonoBehaviour
{
    
    ///////READ ME: Put this on the explosion obj.

    public float blastRadius = 6;
    private float moonY;
    public GameObject moonObj;
    
    // Start is called before the first frame update
    void Start()
    {
        moonObj = GameObject.Find("HexMoon");
        
        moonY = (int) moonObj.transform.localScale.y;
        transform.localScale = new Vector3(blastRadius*2, moonY*2, blastRadius*2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Destroy(gameObject);
        if (collision.gameObject.tag == "Moon")
        {           
            Destroy(collision.gameObject);
            StartCoroutine(moonObj.transform.GetComponent<MoonHealthScript>().CountCurrentChildren());
        }
    }
}
