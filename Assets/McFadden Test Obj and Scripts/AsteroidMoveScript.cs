using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMoveScript : MonoBehaviour
{
    private float max = 40;
    private int speed = 1;
    public float stepSpeed = 1.0F;
    public float scale = 1.0f;
    private float randSp;
    
    private Vector3 RandomVector(float min, float max) 
        {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
        }
    
    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(.25f,3.0f);
        //randSp = Random.Range(.1F, 2.0F);
        
        //get random size (need to be Vector3 not Vector2) if you want to just change x scale 
        Vector3 randomSize = new Vector3 (scale,scale,scale);
        
        //set it to the scale of previously instantiated platform 
        transform.localScale = randomSize;


        var rb = GetComponent<Rigidbody>();
        rb.velocity = RandomVector(0f, 5f);
        /*//set random speed 
        stepSpeed *= Random.Range(1,3);*/

        StartCoroutine(moving());
    }

    // Update is called once per frame
    void Update()
    {        
        /*var pos = transform.position;
        pos.x += speed;
        transform.position = pos;*/

        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);   
    }

    IEnumerator moving()
    {        
        /*var pos = transform.position;
        pos.x += speed;
        transform.position = pos;


        if(pos.x < -5)
        {
            speed =0;
        }*/

        yield return new WaitForSeconds(stepSpeed);   

        StartCoroutine(moving());
    }
}
