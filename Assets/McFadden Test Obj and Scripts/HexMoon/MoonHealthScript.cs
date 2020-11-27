using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonHealthScript : MonoBehaviour
{
    public float startingKids;
    public float currentKids;
    public float win = 50F;
    public float healthPercentage;
    
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
        currentKids = transform.childCount;
        
        Debug.Log(startingKids);
    }

    public IEnumerator CountCurrentChildren()
    {

        /*currentKids = transform.childCount;
        healthPercentage = currentKids/startingKids*100;
        Debug.Log("Moon health: " + healthPercentage);*/
        
        StartCoroutine(FinalCount());
        yield return new WaitForSeconds(.1F); 
        //StartCoroutine(CountCurrentChildren());
    }

    IEnumerator FinalCount()
    {
        yield return new WaitForSeconds(.1F);

        currentKids = transform.childCount;
        healthPercentage = currentKids/startingKids*100;
        Debug.Log("Percentage of Moon Remaining: " + healthPercentage + "%");
                       
        if (healthPercentage <= win)
                {
                    //win game
                    Debug.Log("You blew up more than 50% of the moon! You Win!");
                    //yield return new WaitForSeconds(.1F);
                }
        /*while (true)
        {
            if (healthPercentage <= win)
                {
                    //win game
                    Debug.Log("You blew up more than 50% of the moon! You Win!");
                    //yield return new WaitForSeconds(.1F);
                }
                yield return null;
        }*/
    }

}
