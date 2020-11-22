using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHitScript : MonoBehaviour
{

    public GameObject exp;
    private GameObject exp1;
    private bool boom = true;
    private float boomSize;
    private Vector3 startSpot;
    private Quaternion startRotation;
    private Transform moonSpot;
<<<<<<< HEAD
    private GameObject col;
    private bool rayCheck = false;
    private GameObject[] expObj;
    public float maxSpeed = 7;
    public float maxFuel = 1;
    private float fuel = 1;


    //calculate angles
    //https://answers.unity.com/questions/848244/find-out-direction-vector-of-movement.html
    //public float colAngle;
    //private float[] colPoint;

    //explosion size calc vars
    public float boomSize = 1;
    public float speed = 1;
    public float distToMoonCenter = 1;
=======
    private float distToMoonCenter = 1;
>>>>>>> parent of 65f1207... Moon Hollow and blast radius
    public float distMult = 1;

    //private float speedPerSec;
    private float speed;
    //private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        //oldPosition = transform.position;
        startSpot = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        /*//speedPerSec = Vector3.Distance (oldPosition, transform.position);// / Time.deltaTime;
        speed = Vector3.Distance (oldPosition, transform.position);
        oldPosition = transform.position;*/

        if (Input.GetKey(KeyCode.Return))
        {            
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = startSpot;
            transform.rotation = startRotation;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
<<<<<<< HEAD
        col = collision.gameObject;

        //colPoint = Collision.contacts[0].point

        if (collision.gameObject.tag == "MoonParent" && boom == true)
        {
            rayCheck = true;                       
        }

        //create the explosion
=======
        //Destroy(gameObject);
>>>>>>> parent of 65f1207... Moon Hollow and blast radius
        if (collision.gameObject.tag == "Moon" && boom == true)
        {                      

<<<<<<< HEAD
    IEnumerator explode()
    {
        yield return new WaitForSeconds(.1F);
        Quaternion spawnRotation = Quaternion.Euler(90,0,0);
=======
            Quaternion spawnRotation = Quaternion.Euler(90,0,0);
>>>>>>> parent of 65f1207... Moon Hollow and blast radius

            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 rockVel = rb.velocity;
            speed = rockVel.magnitude;

            //a blast radius of 6 is a pretty good size
            //blast radius = speed * fuel remaining * distance to center of moon * angle of collision            
            moonSpot = exp.GetComponent<destroyOnImpact>().moonObj.transform;
            distToMoonCenter = Vector3.Distance(moonSpot.position, collision.transform.position);
            distMult = moonSpot.localScale.x / distToMoonCenter;

            boomSize = speed;// * distMult;

            if (boomSize > 6)
            {
                boomSize = 6;
            }
            exp.GetComponent<destroyOnImpact>().blastRadius = boomSize;
            exp1 = Instantiate(exp, collision.GetComponent<MeshRenderer>().bounds.center, spawnRotation);

            StartCoroutine(expDie());

            boom = false;
            //StartCoroutine(moonObj.transform.GetComponent<MoonHealthScript>().CountCurrentChildren());

            Destroy(collision.gameObject);
        }
    }

    IEnumerator expDie()
    {
        yield return new WaitForSeconds(.001F); 
        Destroy(exp1);
        boom = true;
    }

}
