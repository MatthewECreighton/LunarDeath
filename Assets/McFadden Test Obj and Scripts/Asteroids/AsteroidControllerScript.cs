using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControllerScript : MonoBehaviour
{
    private float max = 40;
    private int speed = 1;
    public float stepSpeed = 1.0F;
    public float scale = 1.0f;
    private float randSp;

    private Renderer rend;
    private Vector3 viewportPosition;
    private bool isWrappingX = false;
    private bool isWrappingY = false;
    //private bool isVis = true;
    private Vector3 newPosition;
    
    private Vector3 RandomVector(float min, float max) 
    {
    var x = Random.Range(min, max);
    var y = Random.Range(min, max);
    var z = Random.Range(0f,0f);
    return new Vector3(x, y, z);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(.25f,3.0f);
        randSp = Random.Range(.1F, 1F);
        
        //get random size (need to be Vector3 not Vector2) if you want to just change x scale 
        Vector3 randomSize = new Vector3 (scale,scale,scale);
        
        //set it to the scale of previously instantiated platform 
        transform.localScale = randomSize;
        transform.GetComponent<Rigidbody>().mass = scale;
        transform.rotation = Random.rotation;


        var rb = GetComponent<Rigidbody>();
        rb.velocity = RandomVector(-5f, 5f)*randSp;

        
        //wrapping code
        rend = transform.GetComponent<Renderer>();
        var cam = Camera.main; 
        viewportPosition = cam.WorldToViewportPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = transform.position;
        viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if(rend.isVisible)
        {
            //isVis = true;
            isWrappingX = false;
            isWrappingY = false;
            Debug.Log("isVis = true");
        }      
        else
        {
            //isVis = false;            
            Debug.Log("isVis = false");
        } 
    
        if (isWrappingX == false && (viewportPosition.x > 1.1 || viewportPosition.x < -.1))
        {
            //newPosition.x = -newPosition.x;
            newPosition.x = -Camera.main.ScreenToWorldPoint(newPosition).x;
    
            isWrappingX = true;
            Debug.Log("wrapping");
        }
    
        if (isWrappingY == false && (viewportPosition.y > 1.1 || viewportPosition.y < -.1))
        {
            //newPosition.y = -newPosition.y;
            newPosition.y = -Camera.main.ScreenToWorldPoint(newPosition).y;
    
            isWrappingY = true;
            Debug.Log("wrapping");
        }
    
        transform.position = newPosition;
    }
}
