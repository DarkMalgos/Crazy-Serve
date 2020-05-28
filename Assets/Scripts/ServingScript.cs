using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingScript : MonoBehaviour
{
    private bool isServing = false;
    private GameObject client;
    public List<GameObject> drinkOnPlate = new List<GameObject>(); 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isServing)
        {
            for (int i = 0; i< drinkOnPlate.Count; i++)
            {                
                if (drinkOnPlate[i].tag == client.GetComponent<DrinkChoiceScript>().DrinkChoice)
                {
                    Destroy(drinkOnPlate[i]);
                    drinkOnPlate.RemoveAt(i);
                    --i;
                    isServing = false;
                    client.GetComponent<BikerAngerScript>().CalmDown();
                    client.GetComponent<DrinkChoiceScript>().Reset();
                    break;
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
