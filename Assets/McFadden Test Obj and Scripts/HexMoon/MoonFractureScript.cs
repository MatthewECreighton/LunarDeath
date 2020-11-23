using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonFractureScript : MonoBehaviour
{
    public bool fract = false;
    public GameObject moonParent;
    
    public class TransformData 
    {
        public TransformData(Vector3 p, Quaternion r) 
        {
            position = p;
            rotation = r;
        }
        public Vector3 position;
        public Quaternion rotation;
    }
        
    public Dictionary<GameObject, TransformData> originals = new Dictionary<GameObject, TransformData>();
    List <GameObject> currentCollisions = new List <GameObject> ();
    List <GameObject> parts = new List <GameObject> ();

    void OnTrigger (Collision col) 
    { 
        print("moons hitting");
        
        // Add the GameObject collided with to the list.
        currentCollisions.Add (col.gameObject);
        
        foreach (GameObject gObject in currentCollisions)
        {
            if (gObject.transform.gameObject.tag == "Moon")
            {
                parts.Add (gObject);
            }
        }

        //Store each GameObject's position and rotation
        foreach (GameObject gObject in parts) 
        {
            originals.Add(gObject, new TransformData(gObject.transform.position, gObject.transform.rotation));
            Destroy(gObject);
        }
        //Destroy(col.gameObject);
    }

    void Start() 
    {
        /*numParts = grabbableObject.transform.childCount;
        for (int i = 0; i < numParts; i++)
        {
            GameObject thisObj = grabbableObject.transform.GetChild(i).gameObject;
            originals.Add(thisObj, new TransformData(thisObj.transform.position, thisObj..transform.rotation) );
        }*/
    }    
    
    void Update() 
    {
        if (fract == true)
            {
                /*for (int i = 0; i < originals.Count; i++)
                {
                    Instantiate();
                }*/
                foreach (KeyValuePair<GameObject, TransformData> gObject in originals)
                {
                    Instantiate(gObject.Key, gObject.Value.position, gObject.Value.rotation, moonParent.transform);
                }
                StartCoroutine(fracture());
            }
        
        /*if (button pressed) 
        {
            numParts = grabbableObject.transform.childCount;
            for (int i = 0; i < numParts; i++)
            {
                GameObject thisObj = grabbableObject.transform.GetChild(i).gameObject;
                thisObj.transform.position = originals[thisObj].position;
                thisObj.transform.rotation = originals[thisObj].rotation;
            }
        }*/
    }

    IEnumerator fracture()
    {
        yield return new WaitForSeconds(.001F);

        fract = false;
        Destroy(gameObject);
    }
    
}
