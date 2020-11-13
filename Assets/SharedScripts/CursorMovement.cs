using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var hit = new RaycastHit();
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray, 1000f, 1);

        if (hits.Length == 1 && hits[0].transform.tag == "Space") 
        {
            var hitPosition = hits[0].point;
            transform.position = hitPosition;
        }
    }
}
