﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControllerScript : MonoBehaviour
{
    private float max = 40;
    private int speed = 1;
    public float stepSpeed = 1.0F;
    public float scale = 1.0f;
    private float randSp;

    private Renderer renderers;
    private Vector3 viewportPosition;
    private bool isWrappingX = false;
    private bool isWrappingY = false;
    private bool isVis = true;
    
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
        randSp = Random.Range(.1F, .5F);
        
        //get random size (need to be Vector3 not Vector2) if you want to just change x scale 
        Vector3 randomSize = new Vector3 (scale,scale,scale);
        
        //set it to the scale of previously instantiated platform 
        transform.localScale = randomSize;
        transform.GetComponent<Rigidbody>().mass = scale;
        transform.rotation = Random.rotation;


        var rb = GetComponent<Rigidbody>();
        rb.velocity = RandomVector(-5f, 5f)*randSp;

        
        //wrapping code
        renderers = transform.GetComponent<Renderer>();
        var cam = Camera.main; 
        viewportPosition = cam.WorldToViewportPoint(transform.position);

        /*//set random speed 
        stepSpeed *= Random.Range(1,3);*/

        //StartCoroutine(reposition());


    }

    // Update is called once per frame
    void Update()
    {
        if(renderers.isVisible)
        {
            isVis = true;
            isWrappingX = false;
            isWrappingY = false;
            Debug.Log("isVis = true");
        }      
        else
        {
            isVis = false;
            
            Debug.Log("isVis = false");
        }  

        var newPosition = transform.position;
    
        if (isWrappingX == false && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;
    
            isWrappingX = true;
            Debug.Log("wrapping");
        }
    
        if (isWrappingY == false && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;
    
            isWrappingY = true;
            Debug.Log("wrapping");
        }
    
        transform.position = newPosition;

    }

    /*IEnumerator reposition()
    {      
        yield return new WaitForSeconds(stepSpeed);   

        StartCoroutine(moving());
    }*/
}
