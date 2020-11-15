using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDeformScript : MonoBehaviour
{

    //https://catlikecoding.com/unity/tutorials/mesh-deformation/ 

    Mesh deformingMesh;
	Vector3[] originalVertices, displacedVertices;
    Vector3[] vertexVelocities;

    // Start is called before the first frame update
    void Start()
    {
        deformingMesh = GetComponent<MeshFilter>().mesh;
		originalVertices = deformingMesh.vertices;
		displacedVertices = new Vector3[originalVertices.Length];
        vertexVelocities = new Vector3[originalVertices.Length];

		for (int i = 0; i < originalVertices.Length; i++) 
            {
                displacedVertices[i] = originalVertices[i];
            }
    }

    public void AddDeformingForce (Vector3 point, float force) 
    {
		for (int i = 0; i < displacedVertices.Length; i++) 
        {
			AddForceToVertex(i, point, force);
		}
	}

    void AddForceToVertex (int i, Vector3 point, float force) 
    {
        Vector3 pointToVertex = displacedVertices[i] - point;
        float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
        float velocity = attenuatedForce * Time.deltaTime;
        vertexVelocities[i] += pointToVertex.normalized * velocity;
	}

    void Update () 
    {
		for (int i = 0; i < displacedVertices.Length; i++) 
        {
			UpdateVertex(i);
		}
		deformingMesh.vertices = displacedVertices;
		deformingMesh.RecalculateNormals();
	}

    void UpdateVertex (int i) 
    {
		Vector3 velocity = vertexVelocities[i];
		displacedVertices[i] += velocity * Time.deltaTime;
	}
}
