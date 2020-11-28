using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHitScript : MonoBehaviour
{

    public GameObject exp;
    private GameObject exp1;
    private bool boom = true;
    private Vector3 startSpot;
    private Quaternion startRotation;
    private Transform moonSpot;
    private GameObject col;
    private bool rayCheck = false;
    private GameObject[] expObj;
    public float maxSpeed = 7;
    public int lives = 3;

    public float maxFuel = 1;
    private float fuel = 1;
    private float minFuelBoom = .4F;

    public GameObject ExplosionSys;
    private GameObject ExpSys;
    private Vector3 direction;
    private Quaternion look;

    //explosion size calc vars
    public float boomSize = 1;
    public float speed = 1;
    public float distToMoonCenter = 1;
    public float distMult = 1;
    public float fuelMult = 1;
    public float angleMult = 1;
    

    //private float speedPerSec;
    //private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        //oldPosition = transform.position;
        startSpot = transform.position;
        startRotation = transform.rotation;
        fuel = transform.GetComponent<KeyboardMovement>().Fuel;
        maxFuel = fuel;
    }

    // Update is called once per frame
    void Update()
    {
        /*//speedPerSec = Vector3.Distance (oldPosition, transform.position);// / Time.deltaTime;
        speed = Vector3.Distance (oldPosition, transform.position);
        oldPosition = transform.position;*/

        if (Input.GetKey(KeyCode.Return))
        {            
            /*transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = startSpot;
            transform.rotation = startRotation;
            transform.GetComponent<KeyboardMovement>().Fuel = fuel;*/
            StartCoroutine(reset());
        }
        
        //Debug.DrawRay(transform.position, transform.forward*-1, Color.green);  

        if(rayCheck == true)
        {
            Ray ray = new Ray(transform.position, transform.forward*-1);
            RaycastHit hit;          
            print("In the moon");

            if (Physics.Raycast(transform.position, transform.forward*-1, out hit, 10))
            {  
                print("Hit tag is: " + hit.transform.gameObject.tag);
                //colPoint = hit.point;       
                if (hit.transform.gameObject.tag == "Moon")
                {                    
                    print("Trying to shoot moon");
                    col = hit.transform.gameObject;      
                    
                    //create moon explosion
                    //find the vector pointing from our position to the target
                    direction = (transform.position - hit.transform.position).normalized;            
                    //create the rotation we need to be in to look at the target
                    look = Quaternion.LookRotation(direction);
                    ExpSys = Instantiate(ExplosionSys, hit.point, look);
                    
                    StartCoroutine(explode());
                }
            } 
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        col = collision.gameObject;

        if (collision.gameObject.tag == "MoonParent" && boom == true)
        {
            rayCheck = true;                   
        }

        //create the explosion
        if (collision.gameObject.tag == "Moon" && boom == true)
        {                 
            print("hitting it");  
            
            //create moon explosion
            //find the vector pointing from our position to the target
            direction = (transform.position - collision.transform.position).normalized;    
            //create the rotation we need to be in to look at the target
            look = Quaternion.LookRotation(direction);
            
            ExpSys = Instantiate(ExplosionSys, collision.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position), look);
            
            StartCoroutine(explode());
            boom = false;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator reset()
    {
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = startSpot;
        transform.rotation = startRotation;
        transform.GetComponent<KeyboardMovement>().Fuel = maxFuel;
        if (lives != 0)
        {            
            lives -= 1;
            Debug.Log("You have " + lives + " Rockets remaining!");
        }
        else
        {
            Debug.Log("You are out of Rockets!");
        }
        yield return new WaitForSeconds(.001F);
    }

    IEnumerator explode()
    {
        yield return new WaitForSeconds(.001F);
        Quaternion spawnRotation = Quaternion.Euler(90,0,0);
        
        //blast radius = speed * fuel remaining * distance to center of moon * angle of collision  

        //calculate speed
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 rockVel = rb.velocity;
        speed = rockVel.magnitude;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        //calculate distance to center of moon  
        moonSpot = GameObject.FindGameObjectWithTag("MoonParent").transform;
        //moonSpot = GameObject.Find("brokenSphere1k").transform;
        //moonSpot = GameObject.Find("brokenSphere3k").transform;
        //moonSpot = GameObject.Find("HexMoon").transform;
        distToMoonCenter = Vector3.Distance(transform.position, moonSpot.position);
        distMult = moonSpot.localScale.x / distToMoonCenter;
        distMult /= 2;

        //fuel calc
        fuel = transform.GetComponent<KeyboardMovement>().Fuel;
        fuelMult = (fuel/maxFuel) + minFuelBoom;

        //calculate angle of collision

        //calculate the size of the explosion
        boomSize = speed * distMult * fuelMult * angleMult;

        //a blast radius of 6 is a pretty good size
        /*if (boomSize > 6)
        {
            boomSize = 6;
        }*/
        exp.GetComponent<destroyOnImpact>().blastRadius = boomSize;
        exp1 = Instantiate(exp, col.GetComponent<MeshRenderer>().bounds.center, spawnRotation);

        rayCheck = false;
        StartCoroutine(expDie());
    }

    IEnumerator expDie()
    {
        yield return new WaitForSeconds(.001F); 

        expObj = GameObject.FindGameObjectsWithTag ("Explosion");
     
        for(var i = 0 ; i < expObj.Length ; i ++)
        {
            Destroy(expObj[i]);
        }
        StartCoroutine(expPartDie());
        
        StartCoroutine(reset());
        //Destroy(exp1);
        boom = true;
    }

    IEnumerator expPartDie()
    {
        yield return new WaitForSeconds(1F); 

        Destroy(ExpSys);
    }

}