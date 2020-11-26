using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelDisplay : MonoBehaviour
{
    public GameObject Rocket;

    private Transform textChild;

    // Start is called before the first frame update
    void Start()
    {
        textChild = gameObject.transform.GetChild(0);
    }

    void Update() 
    {
        var amount = Rocket.GetComponent<KeyboardMovement>().Fuel;
        int amountTruncated = (int)amount;
        var fuelText = "Fuel: " + amountTruncated.ToString();
        
        textChild.GetComponent<UnityEngine.UI.Text>().text = fuelText;
    }
}
