using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExplosion : MonoBehaviour
{
    public GameObject exp;
    public GameObject expPlace;
    private GameObject boomer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Boom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(1F); 

        //Instantiate()
        boomer = Instantiate(exp, expPlace.transform.position, expPlace.transform.rotation);
        StartCoroutine(BoomGone());
    }

    IEnumerator BoomGone()
    {
        yield return new WaitForSeconds(.1F); 

        //Instantiate()
        //Instantiate(exp, expPlace.transform.position, expPlace.transform.rotation);
          Destroy(boomer);      
    }
}
