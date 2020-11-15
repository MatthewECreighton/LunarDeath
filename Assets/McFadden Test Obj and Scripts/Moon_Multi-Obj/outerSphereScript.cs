using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outerSphereScript : MonoBehaviour
{
    public GameObject outerSphereObj;
    public  GameObject innerSphere;
    private GameObject newouter;
    public float scale;
    private int newouterX;
    private int newouterY;
    private int newouterZ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        newouter = Instantiate(outerSphereObj, transform.position, transform.rotation);
        newouter.transform.parent = innerSphere.transform;
        newouterX = (int) newouter.transform.localScale.x;
        newouterY = (int) newouter.transform.localScale.y;
        newouterZ = (int) newouter.transform.localScale.z;
        //newouter.transform.localScale = new Vector3(newouterX, newouterY, newouterZ); //(int) scale;
        Destroy(gameObject);
    }
}
