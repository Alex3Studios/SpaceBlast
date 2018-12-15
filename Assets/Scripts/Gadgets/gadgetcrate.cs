using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gadgetcrate : MonoBehaviour
{

    public GameObject GadgetHere;
    public GameObject soundPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "PlayerTwo" || hitInfo.tag == "PlayerOne")
        {
            var gadgetsprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            var gadgetFuel = GadgetHere.GetComponent<Gadgets>().fuel;
            if (hitInfo.tag == "PlayerTwo")
            {
                var player = hitInfo.GetComponent<PlayerTwo>();
                player.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = GadgetHere.GetComponent<SpriteRenderer>().sprite;
                player.fuel = gadgetFuel;
                player.fuelCapacity = gadgetFuel;
                GameObject.FindGameObjectWithTag("PlayerTwoGadget").GetComponent<SpriteRenderer>().sprite = gadgetsprite;
                var fuelText = GameObject.FindGameObjectWithTag("PlayerTwoFuel");
                fuelText.GetComponent<UnityEngine.UI.Text>().text = gadgetFuel + "/" + gadgetFuel;
            }
            else
            {
                var player = hitInfo.GetComponent<PlayerOne>();
                player.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = GadgetHere.GetComponent<SpriteRenderer>().sprite;
                player.fuel = gadgetFuel;
                player.fuelCapacity = gadgetFuel;
                GameObject.FindGameObjectWithTag("PlayerOneGadget").GetComponent<SpriteRenderer>().sprite = gadgetsprite;
                var fuelText = GameObject.FindGameObjectWithTag("PlayerOneFuel");
                fuelText.GetComponent<UnityEngine.UI.Text>().text = gadgetFuel + "/" + gadgetFuel;
            }
            Destroy(gameObject);
        }
    }
}
