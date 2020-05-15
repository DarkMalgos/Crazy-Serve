using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingScript : MonoBehaviour
{
    private bool isServing = false;
    private GameObject client;
    public List<string> drinkOnPlate = new List<string>(); 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isServing)
        {
            foreach (string drink in drinkOnPlate)
            {
                if (drink == client.GetComponent<DrinkChoiceScript>().colorOrder)
                {

                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Pnj")
        {
            isServing = true;
            client = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isServing = false;
    }
}
