using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonHealthScript : MonoBehaviour
{
    public int startingKids;
    public int currentKids;
    //public int healthPercentage;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountChildren());
        //StartCoroutine(CountCurrentChildren());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountChildren()
    {
        yield return new WaitForSeconds(1F); 

        startingKids = transform.childCount;
        
        Debug.Log(startingKids);
    }

    public IEnumerator CountCurrentChildren()
    {

        currentKids = transform.childCount;
        //healthPercentage = currentKids/startingKids*100;
        Debug.Log(currentKids);
        
        yield return new WaitForSeconds(2F); 
        //StartCoroutine(CountCurrentChildren());
    }

}
