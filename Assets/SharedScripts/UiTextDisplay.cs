using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTextDisplay : MonoBehaviour
{
    public GameObject Rocket;
    public GameObject Moon;

    private Transform fuelTextChild;
    private Transform livesTextChild;
    private Transform moonTextChild;

    // Start is called before the first frame update
    void Start()
    {
        fuelTextChild = gameObject.transform.Find("Text");
        livesTextChild = gameObject.transform.Find("LivesText");
        moonTextChild = gameObject.transform.Find("MoonText");
    }

    void Update() 
    {
        var amount = Rocket.GetComponent<KeyboardMovement>().Fuel;
        int amountTruncated = (int)amount;
        var fuelText = "Fuel: " + amountTruncated.ToString();

        var livesCount = Rocket.GetComponent<RocketHitScript>().lives.ToString();

        var moonHealth = Moon.GetComponent<MoonHealthScript>().healthPercentage;
        int healthTruncated = moonHealth < 1 ? 100 : (int)moonHealth;
        var moonText = "Moon Health: " + healthTruncated.ToString();
        
        fuelTextChild.GetComponent<UnityEngine.UI.Text>().text = fuelText;
        livesTextChild.GetComponent<UnityEngine.UI.Text>().text = "Lives: " + livesCount.ToString();
        moonTextChild.GetComponent<UnityEngine.UI.Text>().text = moonText;
    }
}
