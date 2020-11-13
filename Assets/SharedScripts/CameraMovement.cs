using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform ObjectToFollow;
    public float HeightOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // camera -6m behind, 1m above
        transform.position = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y + HeightOffset, transform.position.z);
    }
}
