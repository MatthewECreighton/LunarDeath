using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deformScript : MonoBehaviour
{
    //https://answers.unity.com/questions/962794/mesh-collision-damage.html --- this is the code below, so far it works but only with one vert

    
    Vector3[] originalMesh;
    public float deformScale = 1F;
    public LayerMask collisionMask;
    private MeshFilter meshFilter;

    void Start() 
    {
        meshFilter = GetComponent<MeshFilter>();
        originalMesh = meshFilter.mesh.vertices;
    }

    void OnCollisionEnter(Collision collision) 
    {
        Vector3[] meshCoordinates = originalMesh;
        // Loop through collision points
        /*foreach (ContactPoint point in collision.contacts) 
            {
                // Index with the closest distance to point.
                int lastIndex = 0;
                // Loop through mesh coordinates
                for (int i = 0; i < meshCoordinates.Length; i++) {
                    // Check to see if there is a closer index
                    if (Vector3.Distance(point.point, meshCoordinates[i])
                        < Vector3.Distance(point.point, meshCoordinates[lastIndex])) 
                        {
                            // Set the new index
                            lastIndex = i;
                        }
                        
                meshCoordinates[lastIndex] -= meshCoordinates[lastIndex].normalized * deformScale;
            }*/

        foreach (ContactPoint point in collision.contacts) 
            {
                // Index with the closest distance to point.
                //int lastIndex = 0;
                // Loop through mesh coordinates
                for (int i = 0; i < meshCoordinates.Length; i++) 
                    {
                    // Check to see if there is a closer index
                        if (Vector3.Distance(point.point, meshCoordinates[i])
                        < deformScale) 
                            {
                                // Set the new index
                                //lastIndex = i;
                                meshCoordinates[i] -= meshCoordinates[i].normalized * deformScale;
                            }                        
                        //dent inwards
                        //meshCoordinates[lastIndex] -= meshCoordinates[lastIndex].normalized * deformScale;
                        meshCoordinates[i] -= meshCoordinates[i].normalized * deformScale;
                    }

                //meshCoordinates[point.point] -= meshCoordinates[lastIndex].normalized * deformScale;
                //Move the vertex
                //dent inwards

                //random deform
                //meshCoordinates[lastIndex] += new Vector3(Random.Range(-DeformScale,DeformScale), Random.Range(-DeformScale,DeformScale), Random.Range(-DeformScale,DeformScale));

            }

        meshFilter.mesh.vertices = meshCoordinates;
    }

    void Reset() 
    {
        meshFilter.mesh.vertices = originalMesh;
    }
}
