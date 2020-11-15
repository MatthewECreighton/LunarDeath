using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonMove : MonoBehaviour
{
    
    private float max = 40;
    private int speed = 1;
    private bool moveRight = true;
    public float stepSpeed = 1F;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moving());
    }

    // Update is called once per frame
    void Update()
    {        
        /*var pos = transform.position;
        pos.x += speed;
        transform.position = pos;

        
        if(pos.x < max && moveRight == true)
        {
            speed = 1;
        }
        else
        {
            speed = -1;
            moveRight = false;
        }

        if(pos.x < -5)
        {
            speed =0;
        }*/
    }

    IEnumerator moving()
    {        
        var pos = transform.position;
        pos.x += speed;
        transform.position = pos;

        
        if(pos.x < max && moveRight == true)
        {
            speed = 1;
        }
        else
        {
            speed = -1;
            moveRight = false;
        }

        if(pos.x < -5)
        {
            speed =0;
        }
        yield return new WaitForSeconds(stepSpeed);   

        StartCoroutine(moving());
    }
}
