using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMaker : MonoBehaviour
{
    public GameObject innerSphere;
    public GameObject outerSphereObj;
    //public float scale = 3.0f;
    //public int numberOfPoints = 80;

    private int numberOfPoints = 1;
    private float scale = 1;

    private float posX;
    private float posY;
    private float posZ;
 
    // Use this for initialization
    void Start () 
    {
        //make scene obj invisible
        GetComponent<Renderer>().enabled = false;

        //make it the scale of the scene obj
        scale = transform.localScale.x/2;

        //move it to the position of the scene obj
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        //reduce the number of points to scale appropriately with the size
        numberOfPoints = (int) scale;
        numberOfPoints = numberOfPoints * (900/18);
        
        //there are 3 layers in the moon and this is the number of points of each layer
        Vector3[] myPoints1 = GetPointsOnSphere(numberOfPoints);
        Vector3[] myPoints2 = GetPointsOnSphere(numberOfPoints/3);
        Vector3[] myPoints3 = GetPointsOnSphere(numberOfPoints/9);
 
        //layer 1
        foreach (Vector3 point in myPoints1)
        {
            //create the sphere obj
            GameObject outerSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            //put the sphere at the right spot
            outerSphere.transform.position = point * scale;

            //move it in the world to match the scene obj
            outerSphere.transform.position += new Vector3(posX, posY, posZ);

            //give the new obj the script and variables
            outerSphere.AddComponent<outerSphereScript>().outerSphereObj = outerSphereObj;
            outerSphere.GetComponent<outerSphereScript>().innerSphere = innerSphere;
            outerSphere.GetComponent<outerSphereScript>().scale = scale;

            //parent all spheres to the scene obj
            outerSphere.transform.parent = innerSphere.transform;
        }
        //layer 2
        foreach (Vector3 point in myPoints2)
        {
            GameObject outerSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            outerSphere.transform.position = point * (scale/3*2);
            outerSphere.transform.position += new Vector3(posX, posY, posZ);
            outerSphere.AddComponent<outerSphereScript>().outerSphereObj = outerSphereObj;
            outerSphere.GetComponent<outerSphereScript>().innerSphere = innerSphere;
            outerSphere.transform.parent = innerSphere.transform;
        }
        //layer 3
        foreach (Vector3 point in myPoints3)
        {
            GameObject outerSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            outerSphere.transform.position = point * (scale/3);
            outerSphere.transform.position += new Vector3(posX, posY, posZ);
            outerSphere.AddComponent<outerSphereScript>().outerSphereObj = outerSphereObj;
            outerSphere.GetComponent<outerSphereScript>().innerSphere = innerSphere;
            outerSphere.transform.parent = innerSphere.transform;
        }
   
    }
 

    //not sure what this stuff is but I assume it has to do with putting the spheres in the right spot on the scene obj
    Vector3[] GetPointsOnSphere(int nPoints)
    {
        float fPoints = (float)nPoints;
 
        Vector3[] points = new Vector3[nPoints];
 
        float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
        float off = 2 / fPoints;
 
        for (int k = 0; k < nPoints; k++)
        {
            float y = k * off - 1 + (off / 2);
            float r = Mathf.Sqrt(1 - y * y);
            float phi = k * inc;
 
            points[k] = new Vector3(Mathf.Cos(phi) * r, y, Mathf.Sin(phi) * r);
        }
 
        return points;
    }
}
